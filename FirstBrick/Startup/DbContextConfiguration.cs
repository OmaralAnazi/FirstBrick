using FirstBrick.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstBrick.Startup;

public static class DbContextConfiguration
{
    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
