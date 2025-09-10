using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserManagementService.Models;
using UserManagementService.Services;
using Shared.DTOs;

namespace UserManagementService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest request)
        {
            var user = await _userService.UpdateUserProfileAsync(request);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(new UserResponse
            {
                Id = user.Id,
                Handle = user.Handle,
                DisplayName = user.DisplayName,
                Bio = user.Bio,
                ProfilePictureUrl = user.ProfilePictureUrl
            });
        }
    }
}