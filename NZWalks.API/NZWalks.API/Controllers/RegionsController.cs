using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = new List<Region>
            {
                new Region{Id = Guid.NewGuid(), Name = "Wellington", Code = "WLG", Area = 227755, Lat = 1231, Long = 232, Population =  500000 },
                new Region{Id = Guid.NewGuid(), Name = "Auckland", Code = "AUCK", Area = 227755, Lat = 1231, Long = 232, Population =  500000 }
            };

            return Ok(regions);
        }
    }
}
