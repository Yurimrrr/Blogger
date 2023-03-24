namespace Bava.Domain.Entities;

public class Category : Entity
{
    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; }

    public Category()
    {
        
    }

    protected Category(string name) =>
        (Name) = (name);

    public static Category CreateFactory(string name) =>
        new(name);
}