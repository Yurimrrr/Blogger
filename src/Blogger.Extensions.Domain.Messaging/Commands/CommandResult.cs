using FluentValidation.Results;

namespace Blogger.Extensions.Domain.Messaging.Commands;

public class CommandResult : ValidationResult
{
    public CommandResult AddError(string message)
    {
        return AddError(string.Empty, message);
    }

    public CommandResult AddError(string propertyName, string message)
    {
        Errors.Add(new ValidationFailure(propertyName, message));

        return this;
    }
}