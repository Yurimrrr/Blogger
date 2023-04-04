using Bava.Domain.Commands.Contracts;
using FluentValidation;
using FluentValidation.Results;

namespace Bava.Domain.Commands.PostCommands;

internal class PublishPostValidator : AbstractValidator<PublishPostCommand>
{
    public PublishPostValidator()
    {
        RuleFor(x => x.PostId).NotNull();
        RuleFor(x => x.UserId).NotNull();
    }
}

public class PublishPostCommand : ICommand
{
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }

    public ValidationResult Validate()
    {
        var validator = new PublishPostValidator();
        return validator.Validate(this);
    }
}