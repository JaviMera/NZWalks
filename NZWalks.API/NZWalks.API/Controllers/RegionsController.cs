using AutoMapper;
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
        private readonly IMapper _mapper;

        public RegionsController(IRegionsRepository regionsRepository, IMapper mapper)
        {
            _regionsRepository = regionsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            try
            {
                var regionsDomain = await _regionsRepository.GetAllAsync();
                var regions = _mapper.Map<IList<RegionDto>>(regionsDomain);

                return Ok(regions);
            }
            catch (NullReferenceException ex)
            {
                return NotFound("Regions not found");
            }
        }

        [HttpGet]
        [Route("{regionId:guid}")]
        public async Task<IActionResult> GetRegion(Guid regionId)
        {
            try
            {
                var regionDomain = await _regionsRepository.GetAsync(regionId);
                var region = _mapper.Map<RegionDto>(regionDomain);

                return Ok(region);
            }
            catch (NullReferenceException ex)
            {
                return NotFound("Region not found");
            }
        }
    }
}
