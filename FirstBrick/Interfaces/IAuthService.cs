using FirstBrick.Dtos.Requests;
using Microsoft.AspNetCore.Identity;

namespace FirstBrick.Interfaces;

public interface IAuthService
{
    Task<(IdentityResult, string)> RegisterAsync(RegisterDto registerDto);
    Task<string> LoginAsync(LoginDto loginDto);
}
