using Blogger.Extensions.Domain.Messaging.Commands;
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
}