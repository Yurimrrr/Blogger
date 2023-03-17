namespace Bava.Domain.Entities;

public class Post : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }

    public Guid BlogId { get; set; }
    public Blog Blog { get; set; }

    public IEnumerable<Category>? Categories { get; set; } 

    protected Post(string title, string description, Guid blogId, Blog blog, IEnumerable<Category> categories) =>
        (Title, Description, BlogId, Blog, Categories) =
        (title, description, blogId, blog, categories);

    public static Post CreateFactory(string title, string description, Guid blogId, Blog blog,
        IEnumerable<Category> categories) => new(title, description, blogId, blog, categories);
}