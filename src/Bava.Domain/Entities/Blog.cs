namespace Bava.Domain.Entities;

public class Blog : Entity
{
    public Guid OwnerId { get; set; }
    public User Owner { get; set; }
    
    public ICollection<Post> Posts { get; set; }
}