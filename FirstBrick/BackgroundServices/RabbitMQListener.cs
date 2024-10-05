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

    public Task StartAsync(CancellationToken cancellationToken)
    {
        // Subscribe to events
        _bus.PubSub.Subscribe<UserRegisteredEvent>("user_service", HandleUserRegisteredEvent);

        return Task.CompletedTask;
    }

    private void HandleUserRegisteredEvent(UserRegisteredEvent eventMessage)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var handler = scope.ServiceProvider.GetRequiredService<IEventHandler<UserRegisteredEvent>>();
            handler.HandleAsync(eventMessage);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
