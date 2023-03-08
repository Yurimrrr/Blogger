using Blogger.Extensions.Domain.Messaging.Commands;
using MediatR;

namespace Blogger.Extensions.Domain.Messaging.CommonMessages;

public class DomainNotification : Message, INotification
{
    public DomainNotification(string key, string value)
    {
        (Timestamp, DomainNotificationId, Version, Key, Value) =
            (DateTime.Now, Guid.NewGuid(), 1, key, value);
    }

    public DateTime Timestamp { get; protected set; }
    public Guid DomainNotificationId { get; protected set; }
    public string Key { get; protected set; }
    public string Value { get; protected set; }
    public int Version { get; protected set; }
}