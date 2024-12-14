using HA.Auth.ApplicationService.UserModule.Abstract;
using HA.Auth.Dtos.UserModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HA.WebAPI.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create_user")]
        public IActionResult CreateUser([FromBody] CreateUserDto input)
        {
            var user = _userService.CreateNewUser(input);
            return Ok(user);
        }

        [HttpGet("list_user")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpPut("update_user")]
        public IActionResult UpdateUser([FromBody] UpdateUserDto input)
        {
            try
            {
                _userService.UpdateUser(input);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete_user")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
