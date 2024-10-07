using FirstBrick.Entities;

namespace FirstBrick.Dtos.Responses;

public class InvestmentDto(Investment invesment, Fund fund)
{
    public string Id { get; set; } = invesment.Key;
    public string AppUserId { get; set; } = invesment.AppUserId;
    public string FundId { get; set; } = fund.Key;
    public string Status { get; set; } = invesment.status;
    public int Units { get; set; } = invesment.Units;
    public double Amount { get; set; } = invesment.Amount;
    public DateTime CreatedAt { get; set; } = invesment.CreatedAt;
}
