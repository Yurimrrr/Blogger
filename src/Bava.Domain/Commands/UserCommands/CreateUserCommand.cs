using Bava.Domain.Commands.Contracts;
using FluentValidation;
using FluentValidation.Results;

namespace Bava.Domain.Commands.UserCommands;

internal class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Name).MinimumLength(4);
        RuleFor(x => x.Password).MinimumLength(8);
    }
}

public class CreateUserCommand : ICommand
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    
    public ValidationResult Validate()
    {
        var validator = new CreateUserValidator();
        return validator.Validate(this);
    }
}