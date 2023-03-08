using Blogger.Extensions.Domain.Messaging.Commands;
using Blogger.Extensions.Domain.Messaging.CommonMessages;
using FluentValidation.Results;
using MediatR;

namespace Blogger.Extensions.Mediator;

public class MediatorHandler : IMediatorHandler
{
    private readonly IMediator _mediator;

    public MediatorHandler(IMediator mediator) => _mediator = mediator;

    public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
    {
        try
        {
            return await _mediator.Send(command);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void PublishEvent<T>(T @event) where T : Event => _mediator.Publish(@event);
    
    public void PublishNotification<T>(T notification) where T : DomainNotification => _mediator.Publish(notification);

    public void PublishDomainEvent<T>(T domainEvent) => _mediator.Publish(domainEvent);
    
    public void PublishIntegrationEvent<T>(T @event) where T : IntegrationEvent => _mediator.Publish(@event);
}