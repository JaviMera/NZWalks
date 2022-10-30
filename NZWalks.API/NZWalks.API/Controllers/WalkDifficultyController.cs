using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

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
        public async Task<IActionResult> GetAllWalkDifficultyAsync()
        {
            try
            {
                var walkDifficulties = await _repository.GetAllAsync();
                var walkDifficultiesDto = _mapper.Map<IEnumerable<WalkDifficultyDto>>(walkDifficulties);
                return Ok(walkDifficultiesDto);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
        
    }
}
