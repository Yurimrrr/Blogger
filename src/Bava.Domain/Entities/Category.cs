namespace Bava.Domain.Entities;

public class Category : Entity
{
    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; }
}