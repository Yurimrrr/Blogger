using MediatR;

namespace Blogger.Extensions.Domain.Messaging.Commands;

public abstract class Event : Message, INotification
{
    protected Event()
    {
        Timestamp = DateTime.Now;
    }

    public DateTime Timestamp { get; protected set; }
}