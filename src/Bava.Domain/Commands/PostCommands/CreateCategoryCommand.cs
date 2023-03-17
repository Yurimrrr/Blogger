using Bava.Domain.Commands.Contracts;
using Bava.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Bava.Domain.Commands.CategoryCommands;

internal class CreatePostValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostValidator()
    {
        RuleFor(x => x.Title).MinimumLength(3);
    }
}

public class CreatePostCommand : ICommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid BlogId { get; set; }
    public Blog Blog { get; set; }
    public IEnumerable<Category>? Categories { get; set; }
    public ValidationResult Validate()
    {
        var validator = new CreatePostValidator();
        return validator.Validate(this);
    }
}