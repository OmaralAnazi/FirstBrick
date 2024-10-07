using FirstBrick.EventHandlers;
using FirstBrick.Events;
using FirstBrick.Interfaces;
using FirstBrick.Repositories;
using FirstBrick.Services;

namespace FirstBrick.Startup;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IFundService, FundService>();
        services.AddScoped<IFundRepository, FundRepository>();

        // Register event handlers
        services.AddScoped<IEventHandler<UserRegisteredEvent>, UserRegisteredEventHandler>();
        services.AddScoped<IEventHandler<InvestmentRequestedEvent>, InvestmentRequestedEventHandler>();
        services.AddScoped<IEventHandler<InvestmentProcessedEvent>, InvestmentProcessedEventHandler>();

        return services;
    }
}
