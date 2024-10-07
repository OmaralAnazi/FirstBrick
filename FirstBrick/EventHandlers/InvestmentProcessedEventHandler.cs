using FirstBrick.Events;
using FirstBrick.Interfaces;

namespace FirstBrick.EventHandlers;

public class InvestmentProcessedEventHandler(IFundService fundService) : IEventHandler<InvestmentProcessedEvent>
{
    private readonly IFundService _fundService = fundService;

    public async Task HandleAsync(InvestmentProcessedEvent eventMessage)
    {
        await _fundService.UpdateInvestmentStatusAsync(eventMessage.InvestmentId, eventMessage.IsApproved);
    }
}
