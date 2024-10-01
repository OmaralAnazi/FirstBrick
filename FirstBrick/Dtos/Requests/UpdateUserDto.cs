using FirstBrick.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace FirstBrick.Dtos.Requests;

public class UpdateUserDto
{
    [Required]
    [MinLength(3)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(3)]
    public string LastName { get; set; }

    [Required]
    [SaudiPhoneNumber]
    public string PhoneNumber { get; set; }
}
