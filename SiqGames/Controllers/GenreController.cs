using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Entities;

namespace SiqGames.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class GenreController : Controller
    {
        private DAL<Genre> _genreDAL;

        public GenreController(DAL<Genre> GenreDAL)
        {
            _genreDAL = GenreDAL;
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
                _genreDAL.Add(genre);
                return CreatedAtAction(nameof(AddGenre), new { id = genre.GenreId }, genre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<Genre>> SelectGenres()
        {
            try
            {
                var genres = _genreDAL.Get();
                return Ok(genres);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetGenreById(int id)
        {
            var Genre = _genreDAL.GetBy(a => a.GenreId.Equals(id));
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

            var existingGenre = _genreDAL.Get().FirstOrDefault(a => a.GenreId == id);
            if (existingGenre == null)
            {
                return NotFound();
            }

            existingGenre.GenreName = genre.GenreName;
            existingGenre.UserModified = genre.UserModified;

            _genreDAL.Update(existingGenre);
            return Ok(existingGenre);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteGenre(int id)
        {
            var genre = _genreDAL.Get().FirstOrDefault(a => a.GenreId == id);
            if (genre == null)
            {
                return NotFound();
            }

            _genreDAL.Delete(genre);
            return Ok(genre);
        }
    }
}
