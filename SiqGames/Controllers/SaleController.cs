﻿using Microsoft.AspNetCore.Mvc;
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
            if (player == null)
            {
                return NotFound(new { message = "Player not found." });
            }

            Game game = null;
            Dlc dlc = null;

            if (saleRequestViewModel.GameId != null)
            {
                game = context.Games.FirstOrDefault(s => s.Id == saleRequestViewModel.GameId);
                if (game == null)
                {
                    return NotFound(new { message = "Game not found." });
                }
            }

            else if (saleRequestViewModel.DlcId != null)
            {
                dlc = context.Dlcs.FirstOrDefault(s => s.Id == saleRequestViewModel.DlcId);
                if (dlc == null)
                {
                    return NotFound(new { message = "Dlc not found." });
                }
            }

            try
            {
                Sale existingSale = null;

                if (saleRequestViewModel.GameId != null)
                {
                    existingSale = context.Sales
                        .FirstOrDefault(s => s.Player == player && s.Game == game);

                    if (existingSale != null)
                    {
                        return Conflict(new { message = "This player already owns this game." });
                    }
                }

                if (saleRequestViewModel.DlcId != null)
                {
                    existingSale = context.Sales
                        .FirstOrDefault(s => s.Player == player && s.Dlc == dlc);

                    if (existingSale != null)
                    {
                        return Conflict(new { message = "This player already owns this DLC." });
                    }
                }


                var sale = new Sale();

                sale.Game = game;
                sale.Dlc = dlc;
                sale.FinalPrice = saleRequestViewModel.FinalPrice;
                sale.Player = player;
                sale.UserCreated = "Admin";
                sale.DateTimeCreated = DateTime.Now;
                sale.UserModified = "Admin";
                sale.DateTimeModified = DateTime.Now;
                sale.IsActive = true;

                context.Add(sale);
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
                var Sale = context.Sales.ToList();
                return Ok(Sale);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetSaleById(int id)
        {
            var Sale = context.Sales.FirstOrDefault(a => a.Id.Equals(id));
            if (Sale == null)
            {
                return NotFound();
            }
            return Ok(Sale);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateSale(int id, [FromBody] SaleRequestViewModel saleRequestViewModel)
        {
            if (saleRequestViewModel == null)
            {
                return BadRequest(new { message = "Sale data is invalid." });
            }

            var existingSale = context.Sales.FirstOrDefault(a => a.Id.Equals(id));
            if (existingSale == null)
            {
                return NotFound(new { message = "Sale not found." });
            }

            if ((saleRequestViewModel.GameId == null && saleRequestViewModel.DlcId == null) || (saleRequestViewModel.GameId != null && saleRequestViewModel.DlcId != null))
            {
                return BadRequest(new { message = "Sale data is invalid. Is necessary to have one game or one dlc." });
            }

            var player = context.Players.FirstOrDefault(s => s.Id == saleRequestViewModel.PlayerId);
            if (player == null)
            {
                return NotFound(new { message = "Player not found." });
            }

            Game game = null;
            Dlc dlc = null;

            if (saleRequestViewModel.GameId != null)
            {
                game = context.Games.FirstOrDefault(s => s.Id == saleRequestViewModel.GameId);
                if (game == null)
                {
                    return NotFound(new { message = "Game not found." });
                }
            }

            else if (saleRequestViewModel.DlcId != null)
            {
                dlc = context.Dlcs.FirstOrDefault(s => s.Id == saleRequestViewModel.DlcId);
                if (dlc == null)
                {
                    return NotFound(new { message = "Dlc not found." });
                }
            }

            try
            {
                if (saleRequestViewModel.GameId != null)
                {
                    existingSale = context.Sales
                        .FirstOrDefault(s => s.Player == player && s.Game == game);

                    if (existingSale != null)
                    {
                        return Conflict(new { message = "This player already owns this game." });
                    }
                }

                if (saleRequestViewModel.DlcId != null)
                {
                    existingSale = context.Sales
                        .FirstOrDefault(s => s.Player == player && s.Dlc == dlc);

                    if (existingSale != null)
                    {
                        return Conflict(new { message = "This player already owns this DLC." });
                    }
                }

                existingSale.Game = game;
                existingSale.Dlc = dlc;
                existingSale.FinalPrice = saleRequestViewModel.FinalPrice;
                existingSale.Player = player;
                existingSale.UserModified = "Admin";
                existingSale.DateTimeModified = DateTime.Now;
                existingSale.IsActive = true;

                context.Update(existingSale);
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
