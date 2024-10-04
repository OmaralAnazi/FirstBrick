using FirstBrick.Dtos.Requests;
using Microsoft.AspNetCore.Identity;

namespace FirstBrick.Entities;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Birthdate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();

    public AppUser() { } // Parameterless constructor required by EF Core

    public AppUser(RegisterDto registerDto)
    {
        UserName = registerDto.Email;
        Email = registerDto.Email;
        FirstName = registerDto.FirstName;
        LastName = registerDto.LastName;
        PhoneNumber = registerDto.PhoneNumber;
        Birthdate = registerDto.Birthdate;
    }
}
