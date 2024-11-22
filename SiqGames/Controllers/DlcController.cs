using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Entities;

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
        public IActionResult AddDlc([FromBody] Dlc Dlc)
        {
            if (Dlc == null)
            {
                return BadRequest("Dlc data is required.");
            }

            try
            {
                context.Add(Dlc);
                context.SaveChanges();
                return CreatedAtAction(nameof(Dlc), new { id = Dlc.Id }, Dlc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<Dlc>> SelectDlcs()
        {
            try
            {
                var Dlc = context.Set<Dlc>().ToList();
                return Ok(Dlc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetDlcById(int id)
        {
            var Dlc = context.Set<Dlc>().FirstOrDefault(a => a.Id.Equals(id));
            if (Dlc == null)
            {
                return NotFound();
            }
            return Ok(Dlc);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateDlc(int id, [FromBody] Dlc Dlc)
        {
            if (Dlc == null)
            {
                return BadRequest("Dlc data is invalid.");
            }

            var existingDlc = context.Set<Dlc>().FirstOrDefault(a => a.Id.Equals(id));
            if (existingDlc == null)
            {
                return NotFound();
            }

            existingDlc.Title = Dlc.Title;
            existingDlc.Price = Dlc.Price;
            existingDlc.UserModified = Dlc.UserModified;
            existingDlc.IsActive = Dlc.IsActive;

            try
            {
                context.Set<Dlc>().Update(existingDlc);
                context.SaveChanges();
                return Ok(existingDlc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the Dlc: {ex.Message}");
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteDlc(int id)
        {
            var Dlc = context.Set<Dlc>().FirstOrDefault(a => a.Id.Equals(id));
            if (Dlc == null)
            {
                return NotFound();
            }

            context.Set<Dlc>().Remove(Dlc);
            context.SaveChanges();

            return Ok(Dlc);
        }
    }
}
