using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Entities;

namespace SiqGames.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
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
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<Player>> SelectPlayers()
        {
            try
            {
                var players = _playerDAL.Get();
                return Ok(players);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetPlayerById(int id)
        {
            var Player = _playerDAL.GetBy(a => a.PlayerId.Equals(id));
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

            var existingPlayer = _playerDAL.Get().FirstOrDefault(a => a.PlayerId == id);
            if (existingPlayer == null)
            {
                return NotFound();
            }

            existingPlayer.Nickname = player.Nickname;
            existingPlayer.FullName = player.FullName;
            existingPlayer.Email = player.Email;
            existingPlayer.BirthDate = player.BirthDate;
            existingPlayer.UserModified = player.UserModified;

            _playerDAL.Update(existingPlayer);
            return Ok(existingPlayer); 
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeletePlayer(int id)
        {
            var player = _playerDAL.Get().FirstOrDefault(a => a.PlayerId == id);
            if (player == null)
            {
                return NotFound(); 
            }

            _playerDAL.Delete(player);
            return Ok(player);
        }

    }
}
