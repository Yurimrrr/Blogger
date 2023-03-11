namespace Blogger.Extensions.WebAPI.Models;

public class UserInfo
{
    public string Id { get; }
    public string Name { get; }
    public string Email { get; }
    
    public static UserInfo Empty => new("", "", "");

    public UserInfo(string id, string name, string email) =>
        (Id, Name, Email) = (id, name, email);

    public static bool IsNullOrEmpty(UserInfo userInfo) => userInfo.Equals(Empty);

}