using EasyNetQ;
using FirstBrick.Events;
using FirstBrick.Interfaces;

namespace FirstBrick.BackgroundServices;

public class RabbitMQListener : IHostedService
{
    private readonly IBus _bus;
    private readonly IServiceProvider _serviceProvider;

    public RabbitMQListener(IBus bus, IServiceProvider serviceProvider)
    {
        _bus = bus;
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        // NOTE: naming pattern for the subscription ID: "{service_name}_{event_name}"
        await _bus.PubSub.SubscribeAsync<UserRegisteredEvent>("payment_service_user_registered", HandleEvent, cancellationToken: cancellationToken);
        await _bus.PubSub.SubscribeAsync<InvestmentRequestedEvent>("payment_service_investment_requested", HandleEvent, cancellationToken: cancellationToken);
        await _bus.PubSub.SubscribeAsync<InvestmentProcessedEvent>("investment_service_investment_processed", HandleEvent, cancellationToken: cancellationToken);
    }

    private async Task HandleEvent<TEvent>(TEvent eventMessage)
    {
        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<IEventHandler<TEvent>>();
        await handler.HandleAsync(eventMessage);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
