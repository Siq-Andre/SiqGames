using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiqGames.Database;
using SiqGames.Entities;
using SiqGames.ViewModels;

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
        public IActionResult AddGame([FromBody] GameRequestViewModel gameRequestViewModel)
        {
            if (gameRequestViewModel == null)
            {
                return BadRequest(new { message = "Game data is invalid." });
            }

            try
            {
                var studio = context.Studios.FirstOrDefault(s => s.Id == gameRequestViewModel.StudioId);
                if (studio == null)
                {
                    return NotFound(new { message = "Studio not found." });
                }

                var game = new Game();

                game.Title = gameRequestViewModel.Title;
                game.Price = gameRequestViewModel.Price;
                game.Studio = studio;
                game.Description = gameRequestViewModel.Description;
                game.UserCreated = "Admin";
                game.DateTimeCreated = DateTime.Now;
                game.UserModified = "Admin";
                game.DateTimeModified = DateTime.Now;
                game.IsActive = true;

                context.Add(game);
                context.SaveChanges();

                var gameResponse = new GameResponseViewModel
                {
                    GameId = game.Id,
                    Title = game.Title,
                    Price = game.Price,
                    StudioId = gameRequestViewModel.StudioId,
                    Description = game.Description,
                    UserCreated = game.UserCreated,
                    DateTimeCreated = game.DateTimeCreated,
                    UserModified = game.UserModified,
                    DateTimeModified = game.DateTimeModified,
                    IsActive = game.IsActive
                };

                return CreatedAtAction(nameof(AddGame), new { id = game.Id }, gameResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<Game>> SelectGames()
        {
            try
            {
                var games = context.Games
                    .Select(g => new GameResponseViewModel
                    {
                        GameId = g.Id,
                        Title = g.Title,
                        Price = g.Price,
                        StudioId = g.Studio.Id,
                        Description = g.Description,
                        UserCreated = g.UserCreated,
                        DateTimeCreated = g.DateTimeCreated,
                        UserModified = g.UserModified,
                        DateTimeModified = g.DateTimeModified,
                        IsActive = g.IsActive
                    });
                return Ok(games);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetGameById(int id)
        {
            //var game = context.Games.FirstOrDefault(a => a.Id.Equals(id));

            var game = context.Games
                    .Select(g => new GameResponseViewModel
                    {
                        GameId = g.Id,
                        Title = g.Title,
                        Price = g.Price,
                        StudioId = g.Studio.Id,
                        Description = g.Description,
                        UserCreated = g.UserCreated,
                        DateTimeCreated = g.DateTimeCreated,
                        UserModified = g.UserModified,
                        DateTimeModified = g.DateTimeModified,
                        IsActive = g.IsActive
                    })
                    .Where(g => g.GameId == id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateGame(int id, [FromBody] GameRequestViewModel gameRequestViewModel)
        {
            if (gameRequestViewModel == null)
            {
                return BadRequest(new { message = "Game data is invalid." });
            }

            var existingGame = context.Games.FirstOrDefault(a => a.Id.Equals(id));
            if (existingGame == null)
            {
                return NotFound();
            }          

            try
            {
                var studio = new Studio();
                studio.Id = gameRequestViewModel.StudioId;

                context.Attach(studio); //informa o StudioId sem consultar no banco

                existingGame.Title = gameRequestViewModel.Title;
                existingGame.Price = gameRequestViewModel.Price;
                existingGame.Studio = studio;
                existingGame.Description = gameRequestViewModel.Description;
                existingGame.UserModified = "Admin";
                existingGame.DateTimeModified = DateTime.Now;
                existingGame.IsActive = true;

                context.Games.Update(existingGame);
                context.SaveChanges();

                var gameResponse = new GameResponseViewModel
                {
                    GameId = existingGame.Id,
                    Title = existingGame.Title,
                    Price = existingGame.Price,
                    StudioId = gameRequestViewModel.StudioId,
                    Description = existingGame.Description,
                    UserCreated = existingGame.UserCreated,
                    DateTimeCreated = existingGame.DateTimeCreated,
                    UserModified = existingGame.UserModified,
                    DateTimeModified = existingGame.DateTimeModified,
                    IsActive = existingGame.IsActive
                };

                return Ok(gameResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteGame(int id)
        {
            var game = context.Games.FirstOrDefault(a => a.Id.Equals(id));
            if (game == null)
            {
                return NotFound();
            }

            context.Games.Remove(game);
            context.SaveChanges();

            var gameResponse = new GameResponseViewModel
            {
                GameId = game.Id,
                Title = game.Title,
                Price = game.Price,
                StudioId = game.Studio.Id,
                Description = game.Description,
                UserCreated = game.UserCreated,
                DateTimeCreated = game.DateTimeCreated,
                UserModified = game.UserModified,
                DateTimeModified = game.DateTimeModified,
                IsActive = game.IsActive
            };

            return Ok(gameResponse);
        }


    }
}
