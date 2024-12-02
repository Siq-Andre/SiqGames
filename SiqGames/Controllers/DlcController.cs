using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiqGames.Database;
using SiqGames.Entities;
using SiqGames.ViewModels;

namespace SiqGames.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DlcController : Controller
    {
        protected readonly SiqGamesContext context;

        public DlcController(SiqGamesContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult AddDlc([FromBody] DlcRequestViewModel dlcRequestViewModel)
        {
            if (dlcRequestViewModel == null)
            {
                return BadRequest(new { message = "Dlc data is invalid." });
            }

            var game = context.Games.FirstOrDefault(s => s.Id == dlcRequestViewModel.GameId);


            if (game == null)
            {
                return NotFound(new { message = "Game not found." });
            }

            try
            {
                var dlc = new Dlc();

                dlc.Title = dlcRequestViewModel.Title;
                dlc.Price = dlcRequestViewModel.Price;
                dlc.UserCreated = "Admin";
                dlc.DateTimeCreated = DateTime.Now;
                dlc.UserModified = "Admin";
                dlc.DateTimeModified = DateTime.Now;
                dlc.IsActive = true;


                game.Dlcs.Add(dlc);
                
                context.SaveChanges();
                return CreatedAtAction(nameof(AddDlc), new { id = dlc.Id }, dlc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<Dlc>> SelectDlcs()
        {
            try
            {
                var dlc = context.Dlcs.AsNoTracking().ToList();
                return Ok(dlc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetDlcById(int id)
        {
            var dlc = context.Dlcs.AsNoTracking().FirstOrDefault(a => a.Id.Equals(id));
            if (dlc == null)
            {
                return NotFound();
            }
            return Ok(dlc);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateDlc(int id, [FromBody] DlcRequestViewModel dlcRequestViewModel)
        {
            if (dlcRequestViewModel == null)
            {
                return BadRequest(new { message = "Dlc data is invalid." });
            }

            var game = context.Games.Include(x => x.Dlcs).FirstOrDefault(s => s.Id == dlcRequestViewModel.GameId);

            var existingDlc = game.Dlcs.Where(x => x.Id == id).FirstOrDefault();



            if (game == null)
            {
                return NotFound(new { message = "Game not found." });
            }

            if (existingDlc == null)
            {
                return NotFound(new { message = "Dlc does not belong in this game." });
            }

            try
            {
                existingDlc.Title = dlcRequestViewModel.Title;
                existingDlc.Price = dlcRequestViewModel.Price;
                existingDlc.UserModified = "Admin";
                existingDlc.DateTimeModified = DateTime.Now;
                existingDlc.IsActive = true;  

                context.SaveChanges();
                return Ok(existingDlc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteDlc(int id)
        {
            var dlc = context.Dlcs.FirstOrDefault(a => a.Id.Equals(id));
            if (dlc == null)
            {
                return NotFound();
            }

            context.Dlcs.Remove(dlc);
            context.SaveChanges();

            return Ok(dlc);
        }
    }
}
