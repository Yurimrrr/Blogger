using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Blogger.Extensions.Domain;
using FluentValidation;
using FluentValidation.Results;
using MediatR;


namespace Blogger.Extensions.Core.Domain.Abstractions.DomainObjects;

public abstract class Entity<TType> : IEntity
{
    private List<INotification> _domainEvents = new();
    
    [IgnoreDataMember]
    public TType Id { get; protected set; }
    
    [NotMapped]
    [IgnoreDataMember]
    public IReadOnlyCollection<INotification>? DomainEvents => _domainEvents?.AsReadOnly();

    [NotMapped]
    [IgnoreDataMember]
    public bool IsValid { get; protected set; }

    [NotMapped]
    [IgnoreDataMember]
    public ValidationResult? ValidationResult { get; protected set; }

    protected Entity(TType id)
    {
        Id = id;

        if (!IsValidId())
            throw new Exception("Id não é válido ou está vazio");
    }

    public static Guid SequentialGuid()
    {
        var tempGuid = Guid.NewGuid();
        var bytes = tempGuid.ToByteArray();
        var time = DateTime.Now;
        bytes[3] = (byte) time.Year;
        bytes[2] = (byte) time.Month;
        bytes[1] = (byte) time.Day;
        bytes[0] = (byte) time.Hour;
        bytes[5] = (byte) time.Minute;
        bytes[4] = (byte) time.Second;

        return new Guid(bytes);
    }
    
    private bool IsValidId()
    {
        if (Id == null) return false;

        var tryParse = Guid.TryParse(Id.ToString(), out _);
        if (tryParse) 
            return true;

        var typeCode = Type.GetTypeCode(Id.GetType());

        return typeCode switch
        {
            TypeCode.Int16 => short.Parse(Id.ToString() ?? string.Empty) >= 0,
            TypeCode.Int32 => int.Parse(Id.ToString() ?? string.Empty) >= 0,
            TypeCode.Int64 => long.Parse(Id.ToString() ?? string.Empty) >= 0,
            TypeCode.String => !string.IsNullOrEmpty(Id.ToString()),
            _ => false
        };
    }
    
    #region DomainEvents

    public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
    {
        ValidationResult = validator.Validate(model);
        return IsValid = ValidationResult.IsValid;
    }

    public void AddDomainEvent(INotification @event)
    {
        _domainEvents ??= new List<INotification>();
        _domainEvents.Add(@event);
    }

    public void RemoveDomainEvent(INotification domainEventBase)
    {
        _domainEvents?.Remove(domainEventBase);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    #endregion

    #region BaseBehaviours

    public override bool Equals(object? obj)
    {
        var compareTo = obj as Entity<TType>;

        if (ReferenceEquals(this, compareTo)) return true;

        return !ReferenceEquals(null, compareTo) && Id!.Equals(compareTo.Id);
    }

    public static bool operator ==(Entity<TType>? a, Entity<TType>? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity<TType> a, Entity<TType> b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetType().GetHashCode() ^ 93) + Id!.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }

    #endregion
}

public abstract class Entity : Entity<Guid>
{
    protected Entity(System.Guid id) : base(id)
    {
    }

    public class Guid : EntityGuid
    {
        public Guid() : base(System.Guid.Empty)
        {
        }
            
        public Guid(System.Guid id) : base(id)
        {
        }
            
    }
        
    public class Int : EntityInt
    {
        public Int() : base(0)
        {
        }
        public Int(int id) : base(id)
        {
        }
    }

}

public abstract class EntityGuid : Entity<Guid>
{
    protected EntityGuid(Guid id) : base(id)
    {
    }
}
        
public abstract class EntityInt : Entity<int>
{
    protected EntityInt(int id) : base(id)
    {
    }
}


