using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IRegionsRepository _regionRepository;
        private readonly IWalkDifficultyRepository _walkDifficultyRepository;
        private readonly IMapper _mapper;

        public WalksController(
            IWalkRepository walkRepository, 
            IRegionsRepository regionsRepository, 
            IWalkDifficultyRepository walkDifficultyRepository,
            IMapper mapper)
        {
            _walkRepository = walkRepository;
            _regionRepository = regionsRepository;
            _walkDifficultyRepository = walkDifficultyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]        
        public async Task<IActionResult> GetAllWalksAsync()
        {
            try
            {
                var walksDomain = await _walkRepository.GetAllAsync();

                if (!walksDomain.Any())
                    return NoContent();

                var walksDto = _mapper.Map<IList<WalkDto>>(walksDomain);

                return Ok(walksDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        [Route("{walkId:guid}")]
        [ActionName("GetWalkAsync")]        
        public async Task<IActionResult> GetWalkAsync(Guid walkId)
        {
            try
            {
                var walkDomain = await _walkRepository.GetAsync(walkId);

                var walkDto = _mapper.Map<WalkDto>(walkDomain);

                return Ok(walkDto);
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

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddWalkAsync([FromBody] AddWalkDto addWalkDto)
        {
            try
            {
                if(addWalkDto == null)
                {
                    ModelState.AddModelError(nameof(addWalkDto), $"{nameof(addWalkDto)} cannot be empty.");
                    return BadRequest(ModelState);
                }

                if (string.IsNullOrWhiteSpace(addWalkDto.Name))
                {
                    ModelState.AddModelError(nameof(addWalkDto.Name), $"{nameof(addWalkDto.Name)} is required.");
                }

                if (addWalkDto.Length <= 0)
                {
                    ModelState.AddModelError(nameof(addWalkDto.Length), $"{nameof(addWalkDto.Length)} should be greater than zero.");
                }

                var region = await _regionRepository.GetAsync(addWalkDto.RegionId);

                if(region == null)
                {
                    ModelState.AddModelError(nameof(addWalkDto.RegionId), $"{nameof(addWalkDto.RegionId)} RegionId is invalid.");
                }

                var walkDifficulty = await _walkDifficultyRepository.GetWalkDifficultyAsync(addWalkDto.WalkDifficultyId);

                if(walkDifficulty == null)
                {
                    ModelState.AddModelError(nameof(addWalkDto.WalkDifficultyId), $"{nameof(addWalkDto.WalkDifficultyId)} WalkDifficultyId is invalid.");
                }

                if (ModelState.ErrorCount > 0)
                {
                    return BadRequest(ModelState);
                }

                var walkDomain = _mapper.Map<Walk>(addWalkDto);

                var newWalkDomain = await _walkRepository.AddWalkAsync(walkDomain);

                var newWalkDto = _mapper.Map<WalkDto>(newWalkDomain);

                return CreatedAtAction(nameof(GetWalkAsync), new { walkId = newWalkDto.Id }, newWalkDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpPut]
        [Authorize(Roles = "writer")]
        [Route("{walkId:guid}")]       
        public async Task<IActionResult> UpdateWalkAsyn(Guid walkId, [FromBody] UpdateWalkDto updateWalkDto)
        {
            try
            {
                var region = await _regionRepository.GetAsync(updateWalkDto.RegionId);

                if (region == null)
                {
                    ModelState.AddModelError(nameof(updateWalkDto.RegionId), $"{nameof(updateWalkDto.RegionId)} RegionId is invalid.");
                    return BadRequest(ModelState);                    
                }

                var walkDifficulty = await _walkDifficultyRepository.GetWalkDifficultyAsync(updateWalkDto.WalkDifficultyId);

                if (walkDifficulty == null)
                {
                    ModelState.AddModelError(nameof(updateWalkDto.WalkDifficultyId), $"{nameof(updateWalkDto.WalkDifficultyId)} WalkDifficultyId is invalid.");
                    return BadRequest(ModelState);
                }

                var walkToUpdate = _mapper.Map<Walk>(updateWalkDto);
                var updatedWalk = await _walkRepository.UpdateWalkAsync(walkId, walkToUpdate);
                var updatedWalkDto = _mapper.Map<UpdateWalkDto>(updatedWalk);

                return Ok(updatedWalkDto);                
            }
            catch (NullReferenceException exception)
            {
                return NotFound(exception.Message);
            }
            catch(Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "writer")]
        [Route("{walkId:guid}")]        
        public async Task<IActionResult> DeleteWalkAsync(Guid walkId)
        {
            try
            {
                var walkDeleted = await _walkRepository.DeleteWalkAsync(walkId);
                var walkDeletedDto = _mapper.Map<WalkDto>(walkDeleted);

                return Ok(walkDeletedDto);
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
