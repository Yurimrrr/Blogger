namespace Blogger.Extensions.Core.Domain.Abstractions.DomainObjects;

public class AuditableEntity<TType> : Entity<TType>
{
    public virtual DateTime CreatedAt { get; protected set; }
    public virtual string? CreatedBy { get; protected set; }
    public virtual DateTime? LastUpdatedAt { get; protected set; }
    public virtual string? LastUpdatedBy { get; protected set; }
    
    protected AuditableEntity(TType id) : base(id) { }
    
    protected AuditableEntity(TType id, DateTime createdAt) : base(id) =>
        (CreatedAt) = (createdAt);
    
    protected AuditableEntity(TType id, DateTime createdAt, string createdBy) : base(id) =>
        (CreatedAt, CreatedBy) = (createdAt, createdBy);
    
    protected AuditableEntity(TType id, DateTime createdAt, string createdBy, DateTime? updatedAt, string updatedBy) : base(id) =>
        (CreatedAt, CreatedBy, LastUpdatedAt, LastUpdatedBy) = (createdAt, createdBy, updatedAt, updatedBy);

    protected void SetAuditableCreated(DateTime createdAt, string createdBy) =>
        (CreatedAt, CreatedBy) = (createdAt, createdBy);

    protected void SetAuditableUpdate(DateTime? updatedAt, string updatedBy) =>
        (LastUpdatedAt, LastUpdatedBy) = (updatedAt, updatedBy); 
}