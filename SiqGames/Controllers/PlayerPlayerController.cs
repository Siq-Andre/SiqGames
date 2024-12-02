using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Entities;
using SiqGames.ViewModels;
using System.Numerics;

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
        public IActionResult AddPlayerPlayer([FromBody] ViewModels.PlayerPlayerRequestViewModel playerPlayerRequestViewModel)
        {
            if (playerPlayerRequestViewModel == null)
            {
                return BadRequest(new { message = "Players data are invalid." });
            }

            if (playerPlayerRequestViewModel.Player1Id == playerPlayerRequestViewModel.Player2Id)
            {
                return BadRequest(new { message = "Must be 2 diferent players" });
            }

            var checkFriendshipExists = context.PlayerPlayers
                .FirstOrDefault(x =>(x.Player1.Id == playerPlayerRequestViewModel.Player1Id && x.Player2.Id == playerPlayerRequestViewModel.Player2Id) || (x.Player1.Id == playerPlayerRequestViewModel.Player2Id && x.Player2.Id == playerPlayerRequestViewModel.Player1Id));

            if (checkFriendshipExists != null)
            {
                return Conflict(new { message = "Friendship already exists" });
            }

            try
            {
                var player1 = context.Players.FirstOrDefault(s => s.Id == playerPlayerRequestViewModel.Player1Id);

                var player2 = context.Players.FirstOrDefault(s => s.Id == playerPlayerRequestViewModel.Player2Id);

                if (player1 == null || player2 == null)
                {
                    return NotFound(new { message = "One or both players were not found." });
                }

                var playerPlayer = new PlayerPlayer();

                playerPlayer.Player1 = player1;
                playerPlayer.Player2 = player2;
                playerPlayer.UserCreated = "Admin";
                playerPlayer.DateTimeCreated = DateTime.Now;
                playerPlayer.UserModified = "Admin";
                playerPlayer.DateTimeModified = DateTime.Now;
                playerPlayer.IsActive = true;

                context.Add(playerPlayer);
                context.SaveChanges();
                return CreatedAtAction(nameof(AddPlayerPlayer), new { id = playerPlayer.Id }, playerPlayer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<PlayerPlayer>> SelectPlayerPlayer()
        {
            try
            {
                var playerPlayer = context.PlayerPlayers.ToList();
                return Ok(playerPlayer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetPlayerPlayerById(int id)
        {
            var playerPlayer = context.PlayerPlayers.FirstOrDefault(a => a.Id.Equals(id));
            if (playerPlayer == null)
            {
                return NotFound();
            }
            return Ok(playerPlayer);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdatePlayerPlayer(int id, [FromBody] PlayerPlayerRequestViewModel playerPlayerRequestViewModel)
        {
            if (playerPlayerRequestViewModel == null)
            {
                return BadRequest(new { message = "Players data are invalid." });
            }            

            if (playerPlayerRequestViewModel.Player1Id == playerPlayerRequestViewModel.Player2Id)
            {
                return BadRequest(new { message = "Must be 2 diferent players" });
            }           

            var checkFriendshipExists = context.PlayerPlayers
                .FirstOrDefault(x => (x.Player1.Id == playerPlayerRequestViewModel.Player1Id && x.Player2.Id == playerPlayerRequestViewModel.Player2Id) || (x.Player1.Id == playerPlayerRequestViewModel.Player2Id && x.Player2.Id == playerPlayerRequestViewModel.Player1Id));

            if (checkFriendshipExists != null)
            {
                return Conflict(new { message = "Friendship already exists" });
            }

            var existingPlayerPlayer = context.PlayerPlayers.FirstOrDefault(x => x.Id == id);

            if (existingPlayerPlayer == null)
            {
                return NotFound();
            }

            try
            {
                var player1 = context.Players.FirstOrDefault(s => s.Id == playerPlayerRequestViewModel.Player1Id);

                var player2 = context.Players.FirstOrDefault(s => s.Id == playerPlayerRequestViewModel.Player2Id);

                if (player1 == null || player2 == null)
                {
                    return NotFound(new { message = "One or both players were not found." });
                }

                existingPlayerPlayer.Player1 = player1;
                existingPlayerPlayer.Player2 = player2;
                existingPlayerPlayer.UserModified = "Admin";
                existingPlayerPlayer.DateTimeModified = DateTime.Now;
                existingPlayerPlayer.IsActive = true;

                context.PlayerPlayers.Update(existingPlayerPlayer);
                context.SaveChanges();
                return Ok(existingPlayerPlayer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeletePlayerPlayer(int id)
        {
            var playerPlayer = context.PlayerPlayers.FirstOrDefault(a => a.Id.Equals(id));
            if (playerPlayer == null)
            {
                return NotFound();
            }

            context.PlayerPlayers.Remove(playerPlayer);
            context.SaveChanges();

            return Ok(playerPlayer);
        }
    }
}
