using Microsoft.AspNetCore.Mvc;
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

            var game = context.Studios.FirstOrDefault(s => s.Id == dlcRequestViewModel.GameId);

            if (game == null)
            {
                return NotFound(new { message = "Game not found." });
            }

            try
            {
                var dlc = new Dlc();

                dlc.Title = dlcRequestViewModel.Title;
                dlc.Price = dlcRequestViewModel.Price;
                dlc.Game = game; // *******************************************************
                dlc.UserCreated = "Admin";
                dlc.DateTimeCreated = DateTime.Now;
                dlc.UserModified = "Admin";
                dlc.DateTimeModified = DateTime.Now;
                dlc.IsActive = true;

                context.Add(dlc);
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
                var dlc = context.Dlcs.ToList();
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
            var dlc = context.Dlcs.FirstOrDefault(a => a.Id.Equals(id));
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

            var existingDlc = context.Dlcs.FirstOrDefault(a => a.Id.Equals(id));
            if (existingDlc == null)
            {
                return NotFound();
            }

            try
            {
                var game = context.Games.FirstOrDefault(s => s.Id == dlcRequestViewModel.GameId);
                if (game == null)
                {
                    return NotFound(new { message = "Game not found." });
                }

                existingDlc.Title = dlcRequestViewModel.Title;
                existingDlc.Price = dlcRequestViewModel.Price;
                existingDlc.Game = game; // *******************************************************
                existingDlc.UserModified = "Admin";
                existingDlc.DateTimeModified = DateTime.Now;
                existingDlc.IsActive = true;

                context.Dlcs.Update(existingDlc);
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
