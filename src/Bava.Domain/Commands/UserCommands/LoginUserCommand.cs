using Bava.Domain.Commands.Contracts;
using FluentValidation;
using FluentValidation.Results;

namespace Bava.Domain.Commands.UserCommands;

internal class LoginUserValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
    }
}

public class LoginUserCommand : ICommand
{
    public string Email { get; set; }
    public string Password { get; set; }
    
    public ValidationResult Validate()
    {
        var validator = new LoginUserValidator();
        return validator.Validate(this);
    }
}