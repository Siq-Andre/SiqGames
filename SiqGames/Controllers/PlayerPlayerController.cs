using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Entities;

namespace SiqGames.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PlayerPlayerController : Controller
    {
        protected readonly SiqGamesContext context;

        public PlayerPlayerController(SiqGamesContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult AddPlayerPlayer([FromBody] PlayerPlayer PlayerPlayer)
        {
            if (PlayerPlayer == null)
            {
                return BadRequest("PlayerPlayer data is required.");
            }

            try
            {
                context.Add(PlayerPlayer);
                context.SaveChanges();
                return CreatedAtAction(nameof(Dlc), new { id = PlayerPlayer.Id }, PlayerPlayer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<PlayerPlayer>> SelectPlayerPlayer()
        {
            try
            {
                var PlayerPlayer = context.Set<PlayerPlayer>().ToList();
                return Ok(PlayerPlayer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetPlayerPlayerById(int id)
        {
            var PlayerPlayer = context.Set<PlayerPlayer>().FirstOrDefault(a => a.Id.Equals(id));
            if (PlayerPlayer == null)
            {
                return NotFound();
            }
            return Ok(PlayerPlayer);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdatePlayerPlayer(int id, [FromBody] PlayerPlayer PlayerPlayer)
        {
            if (PlayerPlayer == null)
            {
                return BadRequest("PlayerPlayer data is invalid.");
            }

            var existingPlayerPlayer = context.Set<PlayerPlayer>().FirstOrDefault(a => a.Id.Equals(id));
            if (existingPlayerPlayer == null)
            {
                return NotFound();
            }

            existingPlayerPlayer.Player1Id = PlayerPlayer.Player1Id;
            existingPlayerPlayer.Player2Id = PlayerPlayer.Player2Id;
            existingPlayerPlayer.UserModified = PlayerPlayer.UserModified;
            existingPlayerPlayer.IsActive = PlayerPlayer.IsActive;

            try
            {
                context.Set<PlayerPlayer>().Update(existingPlayerPlayer);
                context.SaveChanges();
                return Ok(existingPlayerPlayer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the PlayerPlayer: {ex.Message}");
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeletePlayerPlayer(int id)
        {
            var PlayerPlayer = context.Set<PlayerPlayer>().FirstOrDefault(a => a.Id.Equals(id));
            if (PlayerPlayer == null)
            {
                return NotFound();
            }

            context.Set<PlayerPlayer>().Remove(PlayerPlayer);
            context.SaveChanges();

            return Ok(PlayerPlayer);
        }
    }
}
