using FirstBrick.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace FirstBrick.Dtos.Requests;

public class RegisterDto
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

    [Required]
    [ValidDate]
    public string Birthdate { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}
