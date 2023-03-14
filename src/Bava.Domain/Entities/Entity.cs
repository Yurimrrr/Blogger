namespace Bava.Domain.Entities;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; set; }

    public Entity()
    {
        Id = new Guid();
    }

    public bool Equals(Entity? other)
    {
        if (ReferenceEquals(null, other)) return false;
        return ReferenceEquals(this, other) || Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((Entity)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}