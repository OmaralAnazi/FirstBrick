using FirstBrick.Types;

namespace FirstBrick.Entities;

public class Investment
{
    public int Id { get; set; }
    public string Key { get; set; } = Guid.NewGuid().ToString();
    public string AppUserId { get; set; }
    public string status { get; set; } = InvestmentStatusTypes.PENDING;
    public int FundId { get; set; }
    public int Units { get; set; }
    public double Amount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();

    public Investment() { } // Parameterless constructor required by EF Core

    public Investment(Fund fund, string userId, int units)
    {
        AppUserId = userId;
        FundId = fund.Id;
        Units = units;
        Amount = units * fund.UnitPrice;
    }
}
