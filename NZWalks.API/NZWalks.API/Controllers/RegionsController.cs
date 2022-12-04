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

                if (!regionsDomain.Any())
                    return NoContent();

                var regions = _mapper.Map<IList<RegionDto>>(regionsDomain);
                return Ok(regions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
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

                if(regionDomain == null)
                {
                    return NotFound("Region not found.");
                }

                var region = _mapper.Map<RegionDto>(regionDomain);

                return Ok(region);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionDto addRegionDto)
        {
            try
            {
                // Validate request
                if(addRegionDto == null)
                {
                    ModelState.AddModelError(nameof(addRegionDto), "Add Region Data is required.");
                    return BadRequest(ModelState);
                }

                if (string.IsNullOrWhiteSpace(addRegionDto.Code))
                {
                    var nameOfCode = nameof(addRegionDto.Code);
                    ModelState.AddModelError(nameOfCode, $"{nameOfCode} cannot be empty.");
                }

                if (addRegionDto.Area <= 0)
                {
                    var nameOfArea = nameof(addRegionDto.Area);
                    ModelState.AddModelError(nameOfArea, $"{nameOfArea} cannot be less than or equal to zero.");
                }
              
                if (addRegionDto.Population < 0)
                {
                    var nameOfPopulation = nameof(addRegionDto.Population);
                    ModelState.AddModelError(nameOfPopulation, $"{nameOfPopulation} cannot be less than zero.");
                }

                if(ModelState.ErrorCount > 0)
                {
                    return BadRequest(ModelState);
                }

                var regionDomain = _mapper.Map<Region>(addRegionDto);
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

        [HttpPut]
        [Route("{regionId:guid}")]
        public async Task<IActionResult> UpdateRegionAsync(Guid regionId, [FromBody] UpdateRegionDto updateRegionDto)
        {
            try
            {
                if (updateRegionDto == null)
                {
                    ModelState.AddModelError(nameof(updateRegionDto), "Update Region Data is required.");
                    return BadRequest(ModelState);
                }

                if (string.IsNullOrWhiteSpace(updateRegionDto.Code))
                {
                    var nameOfCode = nameof(updateRegionDto.Code);
                    ModelState.AddModelError(nameOfCode, $"{nameOfCode} cannot be empty.");
                }

                if (updateRegionDto.Area <= 0)
                {
                    var nameOfArea = nameof(updateRegionDto.Area);
                    ModelState.AddModelError(nameOfArea, $"{nameOfArea} cannot be less than or equal to zero.");
                }

                if (updateRegionDto.Population < 0)
                {
                    var nameOfPopulation = nameof(updateRegionDto.Population);
                    ModelState.AddModelError(nameOfPopulation, $"{nameOfPopulation} cannot be less than zero.");
                }

                if (ModelState.ErrorCount > 0)
                {
                    return BadRequest(ModelState);
                }

                var regionDomain = _mapper.Map<Region>(updateRegionDto);

                var updatedRegionDomain = await _regionsRepository.UpdateAsync(regionId, regionDomain);

                var updatedRegionDto = _mapper.Map<UpdateRegionDto>(updatedRegionDomain);

                return Ok(updatedRegionDto);
            }
            catch (NullReferenceException ex)
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
