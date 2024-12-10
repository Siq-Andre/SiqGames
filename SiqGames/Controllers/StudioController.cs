using Microsoft.AspNetCore.Mvc;
using SiqGames.Database;
using SiqGames.Entities;
using SiqGames.ViewModels;

namespace SiqGames.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StudioController : Controller
    {
        protected readonly SiqGamesContext context;

        public StudioController(SiqGamesContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult AddStudio([FromBody] StudioRequestViewModel studioRequestViewModel)
        {
            if (studioRequestViewModel == null)
            {
                return BadRequest(new { message = "Studio data is required." });
            }

            try
            {
                var checkStudioExist = context.Studios.Where(x => x.StudioName == studioRequestViewModel.StudioName).FirstOrDefault();

                if (checkStudioExist != null && checkStudioExist.StudioName == studioRequestViewModel.StudioName)
                {
                    return Conflict(new { message = "Studio already exists" });
                }

                var studio = new Studio();

                studio.StudioName = studioRequestViewModel.StudioName;
                studio.UserCreated = "Admin";
                studio.DateTimeCreated = DateTime.Now;
                studio.UserModified = "Admin";
                studio.DateTimeModified = DateTime.Now;
                studio.IsActive = true;

                context.Add(studio);
                context.SaveChanges();
                return CreatedAtAction(nameof(AddStudio), new { id = studio.Id }, studio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("selectAll")]
        public ActionResult<IEnumerable<Studio>> SelectStudio()
        {
            try
            {
                var studio = context.Studios.ToList();
                return Ok(studio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("selectAll/{page}")]
        public ActionResult<IEnumerable<StudioResponseViewModel>> SelectStudioPage(int page)
        {
            try
            {
                page = page - 1;
                var AmountOfItemsPerPage = 5;
                var SkipAmount = AmountOfItemsPerPage * page;
                var totalStudios = context.Studios.Where(x => x.IsActive == true).Count();

                var studios = context.Studios.Select(x => new StudioResponseViewModel
                {
                    StudioId = x.Id,
                    StudioName = x.StudioName,
                    DateTimeCreated = x.DateTimeCreated,
                    UserCreated = x.UserCreated,
                    DateTimeModified = x.DateTimeModified,
                    UserModified = x.UserModified,
                    IsActive = x.IsActive
                })
                    .Where(x => x.IsActive == true)
                    .Skip(SkipAmount)
                    .Take(AmountOfItemsPerPage)
                    .ToList();

                var totalPages = (int)Math.Ceiling((double)totalStudios / AmountOfItemsPerPage);

                return Ok(new
                {
                    Studio = studios,
                    TotalPages = totalPages
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }
        }

        [HttpGet("select/{id}")]
        public IActionResult GetStudioById(int id)
        {
            var Studio = context.Studios.FirstOrDefault(a => a.Id.Equals(id));
            if (Studio == null)
            {
                return NotFound();
            }
            return Ok(Studio);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateStudio(int id, [FromBody] StudioRequestViewModel studioRequestViewModel)
        {
            if (studioRequestViewModel == null)
            {
                return BadRequest(new { message = "Studio data is invalid." });
            }

            var existingStudio = context.Studios.FirstOrDefault(a => a.Id.Equals(id));
            if (existingStudio == null)
            {
                return NotFound();
            }            

            try
            {
                var checkStudioExists = context.Studios.Where(x => x.Id != existingStudio.Id && x.StudioName == studioRequestViewModel.StudioName).FirstOrDefault();

                if (checkStudioExists != null)
                {
                    return Conflict(new { message = "Studio already exists" });
                }

                existingStudio.StudioName = studioRequestViewModel.StudioName;
                existingStudio.UserModified = "Admin";
                existingStudio.DateTimeModified = DateTime.Now;
                existingStudio.IsActive = true;

                context.Studios.Update(existingStudio);
                context.SaveChanges();
                return Ok(existingStudio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStudio(int id)
        {
            var Studio = context.Studios.FirstOrDefault(a => a.Id.Equals(id));
            if (Studio == null)
            {
                return NotFound();
            }

            context.Studios.Remove(Studio);
            context.SaveChanges();

            return Ok(Studio);
        }

        [HttpPut("delete/{id}")]
        public IActionResult SoftDeleteStudio(int id)
        {
            var studio = context.Studios.FirstOrDefault(a => a.Id.Equals(id));
            if (studio == null)
            {
                return NotFound();
            }

            try
            {
                studio.IsActive = false;

                context.Studios.Update(studio);
                context.SaveChanges();

                var studioResonse = new StudioResponseViewModel
                {
                    StudioId = studio.Id,
                    StudioName = studio.StudioName,
                    DateTimeCreated = studio.DateTimeCreated,
                    UserCreated = studio.UserCreated,
                    DateTimeModified = studio.DateTimeModified,
                    UserModified = studio.UserModified,
                    IsActive = studio.IsActive
                };

                return Ok(studioResonse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error:" + ex.Message });
            }

        }
    }
}
