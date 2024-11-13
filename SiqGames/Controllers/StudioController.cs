using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Entities;

namespace SiqGames.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StudioController : Controller
    {
        private DAL<Studio> _studioDAL;

        public StudioController(DAL<Studio> StudioDAL)
        {
            _studioDAL = StudioDAL;
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
                _studioDAL.Add(studio);
                return CreatedAtAction(nameof(AddStudio), new { id = studio.StudioId }, studio);
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
                var studios = _studioDAL.Get();
                return Ok(studios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetStudioById(int id)
        {
            var Studio = _studioDAL.GetBy(a => a.StudioId.Equals(id));
            if (Studio == null)
            {
                return NotFound();
            }
            return Ok(Studio);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateStudio(int id, [FromBody] Studio studio)
        {
            if (studio == null)
            {
                return BadRequest("Studio data is invalid.");
            }

            var existingStudio = _studioDAL.Get().FirstOrDefault(a => a.StudioId == id);
            if (existingStudio == null)
            {
                return NotFound();
            }

            existingStudio.StudioName = studio.StudioName;

            _studioDAL.Update(existingStudio);
            return Ok(existingStudio);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStudio(int id)
        {
            var studio = _studioDAL.Get().FirstOrDefault(a => a.StudioId == id);
            if (studio == null)
            {
                return NotFound();
            }

            _studioDAL.Delete(studio);
            return Ok(studio);
        }
    }
}
