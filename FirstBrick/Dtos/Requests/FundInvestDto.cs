using System.ComponentModel.DataAnnotations;

namespace FirstBrick.Dtos.Requests;

public class FundInvestDto
{
    [Required]
    public string FundId { get; set; }

    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "The units must be a positive number.")]
    public int Units { get; set; }
}
