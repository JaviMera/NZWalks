using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;
        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto request)
        {
            var user = await _userRepository.AuthenticateAsync(request.Username, request.Password);

            if (user != null)
            {
                return Ok(new
                {
                    Token = _tokenHandler.CreateTokenAsync(user)
                });
            }

            return BadRequest("User credentials are invalid.");
        }
    }
}
