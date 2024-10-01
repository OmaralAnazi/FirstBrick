using FirstBrick.Entities;

namespace FirstBrick.Interfaces;

public interface ITokenService
{
    Task<string> CreateTokenAsync(AppUser user);

}
