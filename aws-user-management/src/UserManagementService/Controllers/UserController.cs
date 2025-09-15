using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserManagementService.Models;
using UserManagementService.Services;
using UserManagementService.DTOs;
using UserManagementService.Services.Interfaces;

namespace UserManagementService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest request)
        {
            var user = await _userService.UpdateUserProfileAsync(request);
            if (!user)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("user")]
        public async Task<IActionResult> GetUser([FromQuery] string handle)
        {
            var user = await _userService.GetUserByIdAsync(handle);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}