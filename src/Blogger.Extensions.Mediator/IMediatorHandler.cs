using Blogger.Extensions.Domain.Messaging.Commands;
using Blogger.Extensions.Domain.Messaging.CommonMessages;
using FluentValidation.Results;

namespace Blogger.Extensions.Mediator;

public interface IMediatorHandler
{
    Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    void PublishEvent<T>(T @event) where T : Event;
    void PublishNotification<T>(T notification) where T : DomainNotification;
    void PublishDomainEvent<T>(T domainEvent);
    void PublishIntegrationEvent<T>(T @event) where T : IntegrationEvent;
}