using Listfy_Application.Services;
using Listfy_Domain.DTOs;
using Listfy_Domain.Entities;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Register([FromBody]UserDTO user)
        {
            var newUser = await _userService.CreateAsync(user);
            return Ok(newUser);
        }
    }
}
