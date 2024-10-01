using FirstBrick.Entities;
using FirstBrick.Data;
using Microsoft.AspNetCore.Identity;

namespace FirstBrick.Startup;

public static class IdentityConfiguration
{
    public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }
}
