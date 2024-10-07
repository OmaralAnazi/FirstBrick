using FirstBrick.Events;
using FirstBrick.Interfaces;

namespace FirstBrick.EventHandlers;

public class InvestmentRequestedEventHandler : IEventHandler<InvestmentRequestedEvent>
{
    private readonly IPaymentService _paymentService;

    public InvestmentRequestedEventHandler(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public async Task HandleAsync(InvestmentRequestedEvent eventMessage)
    {
        await _paymentService.HandleInvestAsync(eventMessage);
    }
}
