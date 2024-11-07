using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Model;

namespace SiqGames.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PlayerController : Controller
    {

        private DAL<Player> _playerDAL;

        public PlayerController(DAL<Player> PlayerDAL)
        {
            _playerDAL = PlayerDAL;
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
                _playerDAL.Add(player);
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
                var players = _playerDAL.Get();
                return Ok(players);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error while retrieving players.");
            }
        }

    }
}
