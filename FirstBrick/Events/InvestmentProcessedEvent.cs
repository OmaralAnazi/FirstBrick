namespace FirstBrick.Events;

public class InvestmentProcessedEvent
{
    public int InvestmentId;
    public bool IsApproved;

    public InvestmentProcessedEvent(int investmentId, bool isApproved)
    {
        InvestmentId = investmentId;
        IsApproved = isApproved;
    }
}
