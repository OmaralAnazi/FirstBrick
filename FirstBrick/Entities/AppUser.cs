using Microsoft.AspNetCore.Identity;

namespace FirstBrick.Entities;

public class AppUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Birthdate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();
}
