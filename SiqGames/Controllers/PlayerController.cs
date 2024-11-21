using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Entities;

namespace SiqGames.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PlayerController : Controller
    {

        protected readonly SiqGamesContext context;

        public PlayerController(SiqGamesContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult AddPlayer([FromBody] Player player)
        {
            if (player == null)
            {
                return BadRequest("Player data is required.");
            }

            try
            {
                context.Add(player);
                context.SaveChanges();
                return CreatedAtAction(nameof(AddPlayer), new { id = player.Id }, player);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<Player>> SelectPlayers()
        {
            try
            {
                var player = context.Set<Player>().ToList();
                return Ok(player);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetPlayerById(int id)
        {
            var Player = context.Set<Player>().FirstOrDefault(a => a.Id.Equals(id));
            if (Player == null)
            {
                return NotFound();
            }
            return Ok(Player);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdatePlayer(int id, [FromBody] Player player)
        {
            if (player == null)
            {
                return BadRequest("Player data is invalid.");
            }

            var existingPlayer = context.Set<Player>().FirstOrDefault(a => a.Id.Equals(id));
            if (existingPlayer == null)
            {
                return NotFound();
            }

            existingPlayer.Nickname = player.Nickname;
            existingPlayer.FullName = player.FullName;
            existingPlayer.Email = player.Email;
            existingPlayer.BirthDate = player.BirthDate;
            existingPlayer.UserModified = player.UserModified;

            try
            {
                context.Set<Player>().Update(existingPlayer);
                context.SaveChanges();
                return Ok(existingPlayer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the player: {ex.Message}");
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeletePlayer(int id)
        {
            var player = context.Set<Player>().FirstOrDefault(a => a.Id.Equals(id));
            if (player == null)
            {
                return NotFound();
            }

            context.Set<Player>().Remove(player);
            context.SaveChanges();

            return Ok(player);
        }

    }
}
