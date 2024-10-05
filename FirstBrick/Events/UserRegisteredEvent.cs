namespace FirstBrick.Events;

public class UserRegisteredEvent
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public UserRegisteredEvent(string userId, string email, string firstName, string lastName)
    {
        UserId = userId;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
}
