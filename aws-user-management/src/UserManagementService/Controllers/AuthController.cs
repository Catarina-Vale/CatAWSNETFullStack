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
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized(result);
        }
    }
}