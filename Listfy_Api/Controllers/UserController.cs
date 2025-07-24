using Listfy_Application.Services;
using Listfy_Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Listfy_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService; 
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]UserDTO user)
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
