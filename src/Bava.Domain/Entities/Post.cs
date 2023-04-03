namespace Bava.Domain.Entities;

public class Post : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Published { get; set; } = false;
    public Guid BlogId { get; set; }
    public Blog Blog { get; set; } = new();

    public IEnumerable<Category>? Categories { get; set; }

    public Post()
    {
    }

    private Post(string title, string description, Guid blogId) =>
        (Title, Description, BlogId) =
        (title, description, blogId);

    /// <summary>
    /// Post creation factory
    /// </summary>
    /// <param name="title">Title of the post</param>
    /// <param name="description">Description of the post</param>
    /// <param name="blogId">Id of the blog that holds the post</param>
    /// <returns></returns>
    public static Post Create(string title, string description, Guid blogId) =>
        new(title, description, blogId);
}