using FirstBrick.Dtos.Requests;
using FirstBrick.Entities;
using FirstBrick.Exceptions;
using FirstBrick.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FirstBrick.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<(IdentityResult, string)> RegisterAsync(RegisterDto registerDto)
    {
        var user = new AppUser(registerDto);
        var result = await _userManager.CreateAsync(user, registerDto.Password);
        var token = await _tokenService.CreateTokenAsync(user);
        return (result, token);
    }

    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email) ?? throw ApiExceptions.Credentials;
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (!result.Succeeded) throw ApiExceptions.Credentials;

        var token = await _tokenService.CreateTokenAsync(user);
        return token;
    }
}
