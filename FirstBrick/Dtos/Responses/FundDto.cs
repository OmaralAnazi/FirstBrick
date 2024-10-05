
using FirstBrick.Entities;

namespace FirstBrick.Dtos.Responses;

public class FundDto(Fund fund)
{
    public string Id { get; set; } = fund.Key;
    public string Name { get; set; } = fund.Name;
    public string Description { get; set; } = fund.Description;
    public double ExpectedReturn { get; set; } = fund.ExpectedReturn;
    public int TotalUnits { get; set; } = fund.TotalUnits;
    public int ReservedUnits { get; set; } = fund.ReservedUnits;
    public double UnitPrice { get; set; } = fund.UnitPrice;
    public int MinimumInvestmentUnits { get; set; } = fund.MinimumInvestmentUnits;
    public int DurationInMonths { get; set; } = fund.DurationInMonths;
    public DateTime CreatedAt { get; set; } = fund.CreatedAt;
}
