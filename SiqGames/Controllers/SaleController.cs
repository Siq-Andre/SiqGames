using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiqGames.Database;
using SiqGames.Entities;
using SiqGames.ViewModels;

namespace SiqGames.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SaleController : Controller
    {
        protected readonly SiqGamesContext context;

        public SaleController(SiqGamesContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult AddSale([FromBody] SaleRequestViewModel saleRequestViewModel)
        {
            if (saleRequestViewModel == null)
            {
                return BadRequest(new { message = "Sale data is invalid." });
            }

            if ((saleRequestViewModel.GameId == null && saleRequestViewModel.DlcId == null) || (saleRequestViewModel.GameId != null && saleRequestViewModel.DlcId != null))
            {
                return BadRequest(new { message = "Sale data is invalid. Is necessary to have one game or one dlc." });
            }

            var player = context.Players.FirstOrDefault(s => s.Id == saleRequestViewModel.PlayerId);

            var game = context.Games.FirstOrDefault(x => x.Id == saleRequestViewModel.GameId);
            var dlc = context.Dlcs.FirstOrDefault(x => x.Id == saleRequestViewModel.DlcId);


            if (player == null)
            {
                return NotFound(new { message = "Player not found." });
            } 
            
            else if (saleRequestViewModel.GameId != null && game == null)
            {
                return NotFound(new { message = "Game not found." });
            }

            else if (saleRequestViewModel.DlcId != null && dlc == null)
            {
                return NotFound(new { message = "Dlc not found." });
            }

            try
            {     
                var sale = new Sale();

                sale.Game = game;
                sale.Dlc = dlc;
                sale.FinalPrice = saleRequestViewModel.FinalPrice;
                sale.UserCreated = "Admin";
                sale.DateTimeCreated = DateTime.Now;
                sale.UserModified = "Admin";
                sale.DateTimeModified = DateTime.Now;
                sale.IsActive = true;

                player.Sales.Add(sale);
                context.SaveChanges();
                return CreatedAtAction(nameof(AddSale), new { id = sale.Id }, sale);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<Sale>> SelectSales()
        {
            try
            {
                var sales = context.Sales.AsNoTracking().ToList();
                return Ok(sales);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetSaleById(int id)
        {
            var sale = context.Sales.AsNoTracking().FirstOrDefault(a => a.Id.Equals(id));
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateSale(int id, [FromBody] SaleRequestViewModel saleRequestViewModel)
        {
            if (saleRequestViewModel == null)
            {
                return BadRequest(new { message = "Sale data is invalid." });
            }

            var player = context.Players.Include(x => x.Sales).FirstOrDefault(s => s.Id == saleRequestViewModel.PlayerId);

            if (player == null)
            {
                return NotFound(new { message = "Player not found." });
            }

            var existingSale = player.Sales.Where(x => x.Id == id).FirstOrDefault();

            if (existingSale == null)
            {
                return NotFound(new { message = "Sale not found." });
            }

            if ((saleRequestViewModel.GameId == null && saleRequestViewModel.DlcId == null) || (saleRequestViewModel.GameId != null && saleRequestViewModel.DlcId != null))
            {
                return BadRequest(new { message = "Sale data is invalid. Is necessary to have one game or one dlc." });
            }

            var game = context.Games.FirstOrDefault(x => x.Id == saleRequestViewModel.GameId);
            var dlc = context.Dlcs.FirstOrDefault(x => x.Id == saleRequestViewModel.DlcId);

            if (saleRequestViewModel.GameId != null && game == null)
            {
                return NotFound(new { message = "Game not found." });
            }

            if (saleRequestViewModel.DlcId != null && dlc == null)
            {
                return NotFound(new { message = "Dlc not found." });
            }


            try
            {
                existingSale.Game = game;
                existingSale.Dlc = dlc;
                existingSale.FinalPrice = saleRequestViewModel.FinalPrice;
                existingSale.UserModified = "Admin";
                existingSale.DateTimeModified = DateTime.Now;
                existingSale.IsActive = true;

                context.SaveChanges();
                return CreatedAtAction(nameof(AddSale), new { id = existingSale.Id }, existingSale);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteSale(int id)
        {
            var Sale = context.Sales.FirstOrDefault(a => a.Id.Equals(id));
            if (Sale == null)
            {
                return NotFound();
            }

            context.Sales.Remove(Sale);
            context.SaveChanges();

            return Ok(Sale);
        }
    }
}
