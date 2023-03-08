using Blogger.Extensions.Domain.Messaging.Commands;

namespace Blogger.Extensions.Domain.Messaging.CommonMessages;

public abstract class DomainEvent : Event
{
    protected DomainEvent(Guid aggregateId) => 
        (AggregateId, Timestamp) = (aggregateId, DateTime.Now);
    
}