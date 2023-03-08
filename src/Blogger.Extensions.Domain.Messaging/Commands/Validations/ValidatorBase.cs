using FluentValidation;

namespace Blogger.Extensions.Domain.Messaging.Commands.Validations;

public abstract class ValidatorBase<T> : AbstractValidator<T> where T : Command
{
    protected bool LinkMustBeAUri(string link)
    {
        return string.IsNullOrEmpty(link) || Uri.TryCreate(link, UriKind.Absolute, out _);
    }
}