using FirstBrick.Dtos.Requests;
using FirstBrick.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstBrick.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;

    public AuthController(IAuthService authService, ITokenService tokenService)
    {
        _authService = authService;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var (result, token) = await _authService.RegisterAsync(registerDto);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok(new { token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var token = await _authService.LoginAsync(loginDto);
        return Ok(new { token });
    }

}
