using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Entities;
using SiqGames.ViewModels;

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
        public IActionResult AddPlayer([FromBody] PlayerRequestViewModel playerViewModel)
        {
            if (playerViewModel == null)
            {
                return BadRequest(new { message = "Player data is required." });
            }

            try
            {

                var checkPlayerExists = context.Players.Where(p => p.Nickname == playerViewModel.Nickname || p.Email == playerViewModel.Email).FirstOrDefault();

                if (checkPlayerExists != null && checkPlayerExists.Nickname == playerViewModel.Nickname)
                {
                    return Conflict(new { message = "Nickname already exists" });                
                }

                else if (checkPlayerExists != null && checkPlayerExists.Email == playerViewModel.Email)
                {
                    return Conflict(new { message = "Email already exists" });
                }

                var player = new Player();

                player.Nickname = playerViewModel.Nickname;
                player.FullName = playerViewModel.FullName;
                player.Email = playerViewModel.Email;
                player.BirthDate = playerViewModel.BirthDate;
                player.UserCreated = "Admin";
                player.DateTimeCreated = DateTime.Now;
                player.UserModified = "Admin";
                player.DateTimeModified =  DateTime.Now;
                player.IsActive = true;

                context.Add(player);
                context.SaveChanges();
                return CreatedAtAction(nameof(AddPlayer), new { id = player.Id }, playerViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<Player>> SelectPlayers()
        {
            try
            {
                var player = context.Players.ToList();
                return Ok(player);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetPlayerById(int id)
        {
            var Player = context.Players.FirstOrDefault(a => a.Id.Equals(id));
            if (Player == null)
            {
                return NotFound();
            }
            return Ok(Player);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdatePlayer(int id, [FromBody] PlayerRequestViewModel playerViewModel)
        {
            if (playerViewModel == null)
            {
                return BadRequest(new {message = "Player data is invalid." });
            }

            var existingPlayer = context.Players.FirstOrDefault(a => a.Id.Equals(id));
            if (existingPlayer == null)
            {
                return NotFound();
            }
                       
            try
            {

                var checkPlayerExists = context.Players.FirstOrDefault(p => p.Id != existingPlayer.Id && (p.Nickname == playerViewModel.Nickname || p.Email == playerViewModel.Email));


                if (checkPlayerExists != null && checkPlayerExists.Nickname == playerViewModel.Nickname)
                {
                    return Conflict(new { message = "Nickname already exists" });
                }

                else if (checkPlayerExists != null && checkPlayerExists.Email == playerViewModel.Email)
                {
                    return Conflict(new { message = "Email already exists" });
                }

                existingPlayer.Nickname = playerViewModel.Nickname;
                existingPlayer.FullName = playerViewModel.FullName;
                existingPlayer.Email = playerViewModel.Email;
                existingPlayer.BirthDate = playerViewModel.BirthDate;
                existingPlayer.UserModified = "Admin";
                existingPlayer.DateTimeModified = DateTime.Now;
                existingPlayer.IsActive = true;

                context.Players.Update(existingPlayer);
                context.SaveChanges();
                return Ok(existingPlayer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeletePlayer(int id)
        {
            var player = context.Players.FirstOrDefault(a => a.Id.Equals(id));
            if (player == null)
            {
                return NotFound();
            }

            context.Players.Remove(player);
            context.SaveChanges();

            return Ok(player);
        }

    }
}
