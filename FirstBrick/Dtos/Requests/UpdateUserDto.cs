using FirstBrick.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace FirstBrick.Dtos.Requests;

public class UpdateUserDto
{
    [MinLength(3)]
    public string? FirstName { get; set; }

    [MinLength(3)]
    public string? LastName { get; set; }

    [SaudiPhoneNumber]
    public string? PhoneNumber { get; set; }
}
