using FirstBrick.Interfaces;
using FirstBrick.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FirstBrick.Enums;

namespace FirstBrick.Services;

public class TokenService : ITokenService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;

    public TokenService(UserManager<AppUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> CreateTokenAsync(AppUser user)
    {
        var claims = new List<Claim>
        {
            new (UserClaimsType.USER_ID, user.Id),
            new (UserClaimsType.EMAIL, user.Email),
            new (UserClaimsType.FIRST_NAME, user.FirstName),
            new (UserClaimsType.LAST_NAME, user.LastName),
            new (UserClaimsType.PHONE_NUMBER, user.PhoneNumber),
        };

        var roles = await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(60), 
            Issuer = _configuration["JWT:Issuer"],
            Audience = _configuration["JWT:Audience"],
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
