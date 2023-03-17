using static System.String;

namespace Bava.Domain.Entities;

public class User : Entity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AvatarUrl { get; set; } = string.Empty;

    protected User(string name, string email, string password, string avatarUrl)
        => (Name, Email, Password, AvatarUrl) = (name, email, password, avatarUrl);

    protected User(string name, string email, string password)
        => (Name, Email, Password) = (name, email, password);
    
    public static User CreateFactory(string name, string email, string password)
        => new(name, email, password);
}