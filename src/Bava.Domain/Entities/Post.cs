namespace Bava.Domain.Entities;

public class Post : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }

    public Guid BlogId { get; set; }
    public Blog Blog { get; set; }

    public ICollection<Category> Categories { get; set; }
}