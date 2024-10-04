using FirstBrick.Entities;

namespace FirstBrick.Dtos.Responses;

public class UserDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Birthdate { get; set; }
    public string CreatedAt { get; set; }

    public UserDto(AppUser user)
    {
        Id = user.Id;
        Email = user.Email;
        FirstName = user.FirstName;
        LastName = user.LastName;
        PhoneNumber = user.PhoneNumber;
        Birthdate = user.Birthdate;
        CreatedAt = user.CreatedAt.ToString();
    }
}
