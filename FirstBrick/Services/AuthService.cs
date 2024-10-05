using EasyNetQ;
using FirstBrick.Dtos.Requests;
using FirstBrick.Entities;
using FirstBrick.Events;
using FirstBrick.Exceptions;
using FirstBrick.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FirstBrick.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IBus _bus; 

    public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IBus bus)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _bus = bus;
    }

    public async Task<(IdentityResult, string)> RegisterAsync(RegisterDto registerDto)
    {
        var user = new AppUser(registerDto);
        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
            return (result, "");

        var userRegisteredEvent = new UserRegisteredEvent(user.Id, user.Email, user.FirstName, user.LastName);
        await _bus.PubSub.PublishAsync(userRegisteredEvent);

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
