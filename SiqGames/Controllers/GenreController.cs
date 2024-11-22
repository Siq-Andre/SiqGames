using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Entities;

namespace SiqGames.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class GenreController : Controller
    {
        protected readonly SiqGamesContext context;

        public GenreController(SiqGamesContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] Genre genre)
        {
            if (genre == null)
            {
                return BadRequest("Genre data is required.");
            }

            try
            {
                context.Add(genre);
                context.SaveChanges();
                return CreatedAtAction(nameof(AddGenre), new { id = genre.Id }, genre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<Genre>> SelectGenres()
        {
            try
            {
                var genre = context.Set<Genre>().ToList();
                return Ok(genre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetGenreById(int id)
        {
            var Genre = context.Set<Genre>().FirstOrDefault(a => a.Id.Equals(id));
            if (Genre == null)
            {
                return NotFound();
            }
            return Ok(Genre);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] Genre genre)
        {
            if (genre == null)
            {
                return BadRequest("Genre data is invalid.");
            }

            var existingGenre = context.Set<Genre>().FirstOrDefault(a => a.Id.Equals(id));
            if (existingGenre == null)
            {
                return NotFound();
            }

            existingGenre.GenreName = genre.GenreName;
            existingGenre.UserModified = genre.UserModified;
            existingGenre.IsActive = genre.IsActive;

            try
            {
                context.Set<Genre>().Update(existingGenre);
                context.SaveChanges();
                return Ok(existingGenre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the genre: {ex.Message}");
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteGenre(int id)
        {
            var genre = context.Set<Genre>().FirstOrDefault(a => a.Id.Equals(id));
            if (genre == null)
            {
                return NotFound();
            }

            context.Set<Genre>().Remove(genre);
            context.SaveChanges();

            return Ok(genre);
        }
    }
}
