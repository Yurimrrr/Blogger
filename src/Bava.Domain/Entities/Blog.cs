namespace Bava.Domain.Entities;

public class Blog : Entity
{
    public Guid OwnerId { get; set; }
    public User Owner { get; set; }

    public IEnumerable<Post> Posts { get; set; } = new List<Post>();

    protected Blog(Guid ownerId, User owner, IEnumerable<Post> posts) =>
        (OwnerId, Owner, Posts) = (ownerId, owner, posts);

    protected Blog(Guid ownerId, User owner) =>
        (OwnerId, Owner) = (ownerId, owner);
    
    public static Blog CreateFactory(Guid ownerId, User owner) =>
        new(ownerId, owner);
}