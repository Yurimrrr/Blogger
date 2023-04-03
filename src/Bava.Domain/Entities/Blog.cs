namespace Bava.Domain.Entities;

public class Blog : Entity
{
    public Guid OwnerId { get; set; }
    public User Owner { get; set; } = new();

    public IEnumerable<Post> Posts { get; set; } = new List<Post>();

    public Blog()
    {
    }

    private Blog(Guid ownerId) =>
        (OwnerId) = (ownerId);

    /// <summary>
    /// Blog creation factory
    /// </summary>
    /// <param name="ownerId">Blog owner id</param>
    /// <returns></returns>
    public static Blog Create(Guid ownerId) =>
        new(ownerId);
}