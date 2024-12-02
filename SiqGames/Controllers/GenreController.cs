using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Entities;
using SiqGames.ViewModels;
using System.Numerics;

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
        public IActionResult AddGenre([FromBody] GenreRequestViewModel genreRequestViewModel)
        {
            if (genreRequestViewModel == null)
            {
                return BadRequest(new { message = "Genre data is required." });
            }

            try
            {
                var checkGenreExists = context.Genres.Where(x => x.GenreName == genreRequestViewModel.GenreName).FirstOrDefault();

                if (checkGenreExists != null && checkGenreExists.GenreName == genreRequestViewModel.GenreName)
                {
                    return Conflict(new { message = "Genre already exists" });
                }

                var genre = new Genre();

                genre.GenreName = genreRequestViewModel.GenreName;
                genre.UserCreated = "Admin";
                genre.DateTimeCreated = DateTime.Now;
                genre.UserModified = "Admin";
                genre.DateTimeModified = DateTime.Now;
                genre.IsActive = true;

                context.Add(genre);
                context.SaveChanges();
                return CreatedAtAction(nameof(AddGenre), new { id = genre.Id }, genre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<Genre>> SelectGenres()
        {
            try
            {
                var genre = context.Genres.ToList();
                return Ok(genre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetGenreById(int id)
        {
            var genre = context.Genres.FirstOrDefault(a => a.Id.Equals(id));
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] GenreRequestViewModel genreRequestViewModel)
        {
            if (genreRequestViewModel == null)
            {
                return BadRequest(new { message = "Genre data is invalid." });
            }

            var existingGenre = context.Genres.FirstOrDefault(a => a.Id.Equals(id));
            if (existingGenre == null)
            {
                return NotFound();
            }            

            try
            {
                var checkGenreExists = context.Genres.Where(x => x.Id != existingGenre.Id && x.GenreName == genreRequestViewModel.GenreName).FirstOrDefault();

                if (checkGenreExists != null)
                {
                    return Conflict(new { message = "Genre already exists" });
                }

                existingGenre.GenreName = genreRequestViewModel.GenreName;
                existingGenre.UserModified = "Admin";
                existingGenre.DateTimeModified = DateTime.Now;
                existingGenre.IsActive = true;

                context.Genres.Update(existingGenre);
                context.SaveChanges();
                return Ok(existingGenre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteGenre(int id)
        {
            var genre = context.Genres.FirstOrDefault(a => a.Id.Equals(id));
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
