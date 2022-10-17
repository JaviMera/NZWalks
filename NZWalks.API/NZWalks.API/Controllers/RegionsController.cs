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
        public async Task<IActionResult> GetAllRegionsAsync()
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
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid regionId)
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

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionDto regionDto)
        {
            try
            {
                var regionDomain = _mapper.Map<Region>(regionDto);
                var newRegion = await _regionsRepository.AddAsync(regionDomain);

                var newRegionDto = _mapper.Map<RegionDto>(newRegion);

                return CreatedAtAction(nameof(GetRegionAsync), new { regionId = newRegionDto.Id }, newRegionDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{regionId:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid regionId)
        {
            try
            {
                var regionDeleted = await _regionsRepository.DeleteAsync(regionId);
                var regionDeletedDto = _mapper.Map<RegionDto>(regionDeleted);

                return Ok(regionDeletedDto);
            }
            catch(NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
