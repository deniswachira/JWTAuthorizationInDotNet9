using JWTAuthorizationInDotNet9.DTO;
using JWTAuthorizationInDotNet9.Entities;
using JWTAuthorizationInDotNet9.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthorizationInDotNet9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
           var user = await authService.RegisterAsync(request);
            if (user == null)
                return BadRequest("Username already exist");

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login (UserDto request)
        {
            var result = await authService.LoginAsync(request);
            if (result == null) 
                return BadRequest("Invalid username or Password");

            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var result = await authService.RefreshTokenAsync(request);
            if (result is null || result.AccesToken is null || result.RefreshToken is null)
                return BadRequest("Invalid refresh Token");
        
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok("Your Are Authenticated");
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("Your Are Authenticated and you are admin");
        }
    }
}
