using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using System.Data;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository _repository;
        private readonly IMapper _mapper;

        public WalkDifficultyController(IWalkDifficultyRepository repository, IMapper maper)
        {
            _repository = repository;
            _mapper = maper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllWalkDifficultyAsync()
        {
            try
            {
                var walkDifficulties = await _repository.GetAllAsync();

                if (!walkDifficulties.Any())
                {
                    return NotFound("There are no walk difficulties found.");
                }

                var walkDifficultiesDto = _mapper.Map<IEnumerable<WalkDifficultyDto>>(walkDifficulties);
                return Ok(walkDifficultiesDto);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        [Route("{walkDifficultyId:guid}")]
        [ActionName("GetWalkDifficultyAsync")]
        public async Task<IActionResult> GetWalkDifficultyAsync(Guid walkDifficultyId)
        {
            try
            {
                var walkDifficulty = await _repository.GetWalkDifficultyAsync(walkDifficultyId);

                if(walkDifficulty == null)
                {
                    return NotFound("WalkDifficulty not found.");
                }

                var walkDifficultyDto = _mapper.Map<WalkDifficultyDto>(walkDifficulty);

                return Ok(walkDifficultyDto);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddWalkDifficultyAsync([FromBody] AddWalktDifficultyDto addWalkDifficultyDto)
        {
            try
            {               
                var walkDifficultyDomain = _mapper.Map<WalkDifficulty>(addWalkDifficultyDto);
                var newWalkDifficulty = await _repository.AddWalkDifficulty(walkDifficultyDomain);
                var newWalkDifficultyDto = _mapper.Map<WalkDifficultyDto>(newWalkDifficulty);

                return CreatedAtAction(nameof(GetWalkDifficultyAsync), new { walkDifficultyId = newWalkDifficultyDto.Id }, newWalkDifficultyDto);                
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "writer")]
        [Route("{walkDifficultyId:guid}")]
        public async Task<IActionResult> DeleteWalkDifficultyAsync(Guid walkDifficultyId)
        {
            try
            {
                var difficultyDeleted = await _repository.DeleteWalkDifficultyAsync(walkDifficultyId);
                var difficultyDeletedDto = _mapper.Map<WalkDifficultyDto>(difficultyDeleted);

                return Ok(difficultyDeletedDto);
            }
            catch(NullReferenceException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "writer")]
        [Route("{walkDifficultyId:guid}")]
        public async Task<IActionResult> UpdateWalkDifficultyAsync(Guid walkDifficultyId, [FromBody] UpdateWalkDifficultyDto updateWalkDifficulty)
        {
            try
            {
                var walkDifficultyDomain = _mapper.Map<WalkDifficulty>(updateWalkDifficulty);

                var updatedWalkDifficulty = await _repository.UpdateAsync(walkDifficultyId, walkDifficultyDomain);
                var updatedWalkDifficultyDto = _mapper.Map<WalkDifficultyDto>(updatedWalkDifficulty);

                return Ok(updatedWalkDifficultyDto);
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
    }
}
