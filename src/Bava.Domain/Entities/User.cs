using static System.String;

namespace Bava.Domain.Entities;

public class User : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;

    public User()
    {
    }

    private User(string name, string email, string password)
        => (Name, Email, Password) = (name, email, password);

    /// <summary>
    /// User creation factory
    /// </summary>
    /// <param name="name">Name of the user</param>
    /// <param name="email">Email of the user</param>
    /// <param name="password">Password of the user</param>
    /// <returns></returns>
    public static User Create(string name, string email, string password)
        => new(name, email, password);
}