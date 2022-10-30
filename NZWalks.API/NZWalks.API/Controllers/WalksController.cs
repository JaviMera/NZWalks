using AutoMapper;
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
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
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
        public async Task<IActionResult> AddWalkAsync([FromBody] AddWalkDto walktDo)
        {
            try
            {
                var walkDomain = _mapper.Map<Walk>(walktDo);

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
        [Route("{walkId:guid}")]
        public async Task<IActionResult> UpdateWalkAsyn(Guid walkId, [FromBody] UpdateWalkDto updateWalkDto)
        {
            try
            {
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
