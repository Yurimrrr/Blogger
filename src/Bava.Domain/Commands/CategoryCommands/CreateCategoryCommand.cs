using Bava.Domain.Commands.Contracts;
using FluentValidation;
using FluentValidation.Results;

namespace Bava.Domain.Commands.CategoryCommands;

internal class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3);
    }
}

public class CreateCategoryCommand : ICommand
{
    public string Name { get; set; }

    public ValidationResult Validate()
    {
        var validator = new CreateCategoryValidator();
        return validator.Validate(this);
    }
}