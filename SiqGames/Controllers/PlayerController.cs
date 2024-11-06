using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Model;

namespace SiqGames.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PlayerController : Controller
    {

        private SiqGamesContext _context;

        public PlayerController(SiqGamesContext context)
        {
            _context = context;
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
                _context.Players.Add(player);
                _context.SaveChanges();
                return CreatedAtAction(nameof(AddPlayer), new { id = player.PlayerId }, player);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error while adding player.");
            }
        }

        [HttpGet("select")]
        public ActionResult<IEnumerable<Player>> SelectPlayers()
        {
            try
            {
                var players = _context.Players.ToList();
                return Ok(players);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error while retrieving players.");
            }
        }

    }
}
