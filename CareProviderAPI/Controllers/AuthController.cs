using CareProviderAPI.Data.DTOs.UserDTO;
using CareProviderAPI.Services.Implementations;
using CareProviderAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareProviderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            var result = await authService.Register(registerDTO);
            return Ok(new { message = result });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var result = await authService.ValidateUser(loginDTO);
            if (result is null)
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(result);
        }
    }
}
