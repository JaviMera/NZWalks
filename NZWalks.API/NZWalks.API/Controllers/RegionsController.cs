using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionsRepository _regionsRepository;

        public RegionsController(IRegionsRepository regionsRepository)
        {
            _regionsRepository = regionsRepository;
        }

        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = _regionsRepository.GetAll()
                .ToList()
                .Select(region => new RegionDto
                {
                    Area = region.Area,
                    Code = region.Code,
                    Id = region.Id,
                    Lat = region.Lat,
                    Long = region.Long,
                    Name = region.Name,
                    Population = region.Population
                });

            return Ok(regions);
        }
    }
}
