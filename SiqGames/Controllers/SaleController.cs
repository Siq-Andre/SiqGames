using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Entities;

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
        public IActionResult AddSale([FromBody] Sale Sale)
        {
            if (Sale == null)
            {
                return BadRequest("Sale data is required.");
            }

            try
            {
                context.Add(Sale);
                context.SaveChanges();
                return CreatedAtAction(nameof(Sale), new { id = Sale.Id }, Sale);
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
                var Sale = context.Set<Sale>().ToList();
                return Ok(Sale);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetSaleById(int id)
        {
            var Sale = context.Set<Sale>().FirstOrDefault(a => a.Id.Equals(id));
            if (Sale == null)
            {
                return NotFound();
            }
            return Ok(Sale);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateSale(int id, [FromBody] Sale Sale)
        {
            if (Sale == null)
            {
                return BadRequest("Sale data is invalid.");
            }

            var existingSale = context.Set<Sale>().FirstOrDefault(a => a.Id.Equals(id));
            if (existingSale == null)
            {
                return NotFound();
            }

            existingSale.FinalPrice = Sale.FinalPrice;
            existingSale.UserModified = Sale.UserModified;
            existingSale.IsActive = Sale.IsActive;

            try
            {
                context.Set<Sale>().Update(existingSale);
                context.SaveChanges();
                return Ok(existingSale);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the Sale: {ex.Message}");
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteSale(int id)
        {
            var Sale = context.Set<Sale>().FirstOrDefault(a => a.Id.Equals(id));
            if (Sale == null)
            {
                return NotFound();
            }

            context.Set<Sale>().Remove(Sale);
            context.SaveChanges();

            return Ok(Sale);
        }
    }
}
