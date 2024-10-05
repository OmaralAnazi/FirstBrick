using FirstBrick.Dtos.Requests;

namespace FirstBrick.Entities;

public class Fund
{
    public int Id { get; set; }
    public string Key { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Description { get; set; }
    public double ExpectedReturn { get; set; }
    public int TotalUnits { get; set; }
    public int ReservedUnits { get; set; } = 0;
    public double UnitPrice { get; set; }
    public int MinimumInvestmentUnits { get; set; }
    public int DurationInMonths { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();

    public Fund() { } // Parameterless constructor required by EF Core

    public Fund(CreateFundDto createFundDto)
    {
        Name = createFundDto.Name;
        Description = createFundDto.Description;
        ExpectedReturn = createFundDto.ExpectedReturn;
        TotalUnits = createFundDto.TotalUnits;
        UnitPrice = createFundDto.UnitPrice;
        MinimumInvestmentUnits = createFundDto.MinimumInvestmentUnits;
        DurationInMonths = createFundDto.DurationInMonths;
    }
}
