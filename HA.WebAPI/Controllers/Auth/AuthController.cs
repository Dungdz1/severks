using HA.Auth.ApplicationService.UserModule.Abstract;
using HA.Auth.Dtos.Logg;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HA.WebAPI.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto input)
        {
            var response = await _userService.LoginAsync(input);
            return Ok(response);
        }
    }
}
