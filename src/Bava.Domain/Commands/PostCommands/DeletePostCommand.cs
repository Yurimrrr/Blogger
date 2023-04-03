using Bava.Domain.Commands.Contracts;
using FluentValidation;
using FluentValidation.Results;

namespace Bava.Domain.Commands.PostCommands;

internal class DeletePostValidator : AbstractValidator<DeletePostCommand>
{
    public DeletePostValidator()
    {
        RuleFor(x => x.UserId).NotNull();
        RuleFor(x => x.PostId).NotNull();
    }
}

public class DeletePostCommand : ICommand
{
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }

    public ValidationResult Validate()
    {
        var validator = new DeletePostValidator();
        return validator.Validate(this);
    }
}