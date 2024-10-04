using FirstBrick.Interfaces;
using FirstBrick.Services;

namespace FirstBrick.Startup;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
