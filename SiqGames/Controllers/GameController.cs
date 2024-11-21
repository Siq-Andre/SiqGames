using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiqGames.Database;
using SiqGames.Entities;

namespace SiqGames.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class GameController : Controller
    {
        protected readonly SiqGamesContext context;

        public GameController(SiqGamesContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult AddGame([FromBody] Game game)
        {
            if (game == null)
            {
                return BadRequest("Game data is required.");
            }

            try
            {
                context.Add(game);
                context.SaveChanges();
                return CreatedAtAction(nameof(AddGame), new { id = game.Id }, game);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<Game>> SelectGames()
        {
            try
            {
                var games = context.Set<Game>().ToList();
                return Ok(games);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetGameById(int id)
        {
            var Game = context.Set<Game>().FirstOrDefault(a => a.Id.Equals(id));
            if (Game == null)
            {
                return NotFound();
            }
            return Ok(Game);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateGame(int id, [FromBody] Game game)
        {
            if (game == null)
            {
                return BadRequest("Game data is invalid.");
            }

            var existingGame = context.Set<Game>().FirstOrDefault(a => a.Id.Equals(id));
            if (existingGame == null)
            {
                return NotFound();
            }

            existingGame.Title = game.Title;
            existingGame.Price = game.Price;
            existingGame.Description = game.Description;
            existingGame.UserModified = game.UserModified;       

            try
            {
                context.Set<Game>().Update(existingGame);
                context.SaveChanges();
                return Ok(existingGame);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the game: {ex.Message}");
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteGame(int id)
        {
            var game = context.Set<Game>().FirstOrDefault(a => a.Id.Equals(id));
            if (game == null)
            {
                return NotFound();
            }

            context.Set<Game>().Remove(game);
            context.SaveChanges();

            return Ok(game);
        }


    }
}
