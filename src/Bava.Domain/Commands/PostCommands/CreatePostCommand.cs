using Bava.Domain.Commands.Contracts;
using FluentValidation;
using FluentValidation.Results;

namespace Bava.Domain.Commands.PostCommands;

internal class CreatePostValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostValidator()
    {
        RuleFor(x => x.Title).MinimumLength(3);
        RuleFor(x => x.Description).MinimumLength(3);
        RuleFor(x => x.BlogId).NotNull();
    }
}

public class CreatePostCommand : ICommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid BlogId { get; set; }

    public ValidationResult Validate()
    {
        var validator = new CreatePostValidator();
        return validator.Validate(this);
    }
}