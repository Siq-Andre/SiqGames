using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Entities;

namespace SiqGames.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StudioController : Controller
    {
        protected readonly SiqGamesContext context;

        public StudioController(SiqGamesContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult AddStudio([FromBody] Studio studio)
        {
            if (studio == null)
            {
                return BadRequest("Studio data is required.");
            }

            try
            {
                context.Add(studio);
                context.SaveChanges();
                return CreatedAtAction(nameof(AddStudio), new { id = studio.Id }, studio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<Studio>> SelectStudio()
        {
            try
            {
                var studio = context.Set<Studio>().ToList();
                return Ok(studio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetStudioById(int id)
        {
            var Studio = context.Set<Studio>().FirstOrDefault(a => a.Id.Equals(id));
            if (Studio == null)
            {
                return NotFound();
            }
            return Ok(Studio);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateStudio(int id, [FromBody] Studio Studio)
        {
            if (Studio == null)
            {
                return BadRequest("Studio data is invalid.");
            }

            var existingStudio = context.Set<Studio>().FirstOrDefault(a => a.Id.Equals(id));
            if (existingStudio == null)
            {
                return NotFound();
            }

            existingStudio.StudioName = Studio.StudioName;
            existingStudio.UserModified = Studio.UserModified;

            try
            {
                context.Set<Studio>().Update(existingStudio);
                context.SaveChanges();
                return Ok(existingStudio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the game: {ex.Message}");
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStudio(int id)
        {
            var Studio = context.Set<Studio>().FirstOrDefault(a => a.Id.Equals(id));
            if (Studio == null)
            {
                return NotFound();
            }

            context.Set<Studio>().Remove(Studio);
            context.SaveChanges();

            return Ok(Studio);
        }
    }
}
