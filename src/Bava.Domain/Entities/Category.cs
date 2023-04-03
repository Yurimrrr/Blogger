namespace Bava.Domain.Entities;

public class Category : Entity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Post> Posts { get; set; } = new List<Post>();

    public Category()
    {
    }

    protected Category(string name) =>
        (Name) = (name);

    /// <summary>
    /// Category creation factory
    /// </summary>
    /// <param name="name">Name of the category</param>
    /// <returns></returns>
    public static Category Create(string name) =>
        new(name);
}