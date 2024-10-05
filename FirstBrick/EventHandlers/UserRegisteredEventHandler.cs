using FirstBrick.Events;
using FirstBrick.Interfaces;

namespace FirstBrick.EventHandlers;

public class UserRegisteredEventHandler : IEventHandler<UserRegisteredEvent>
{
    private readonly IPaymentService _paymentService;

    public UserRegisteredEventHandler(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public async Task HandleAsync(UserRegisteredEvent eventMessage) 
    {
        await _paymentService.CreateWalletAsync(eventMessage.UserId);
    }
}

