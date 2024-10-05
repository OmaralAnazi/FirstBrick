using System.ComponentModel.DataAnnotations;

namespace FirstBrick.Dtos.Requests;

public class CreateFundDto
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; }

    [Required]
    [MinLength(3)]
    public string Description { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "The ExpectedReturn must be a positive number.")]
    public double ExpectedReturn { get; set; }

    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "The TotalUnits must be a positive number.")]
    public int TotalUnits { get; set; }

    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "The UnitPrice must be a positive number.")]
    public double UnitPrice { get; set; }

    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "The MinimumInvestmentUnits must be a positive number.")]
    public int MinimumInvestmentUnits { get; set; }

    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "The DurationInMonths must be a positive number.")]
    public int DurationInMonths { get; set; }
}
