using Listfy_Application.Services;
using Listfy_Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Listfy_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]UserDTO user)
        {
            var newUser = await _userService.CreateAsync(user);
            return StatusCode(201, newUser);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
    }
}
