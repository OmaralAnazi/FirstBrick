namespace FirstBrick.Events;

public class InvestmentRequestedEvent
{
    public int InvestmentId { get; set; }
    public string UserId { get; set; }
    public double Amount { get; set; }

    public InvestmentRequestedEvent(int investmentId, string userId, double amount)
    {
        InvestmentId = investmentId;
        UserId = userId;
        Amount = amount;
    }
}
