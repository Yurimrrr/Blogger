using Blogger.Extensions.Domain.Messaging.Commands;
using FluentValidation.Results;

namespace Blogger.Extensions.Mediator;

public interface IMediatorHandler
{
    Task<ValidationResult> SendCommand<T>(T command) where T : Command;
}