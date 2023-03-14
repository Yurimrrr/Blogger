using FluentValidation.Results;

namespace Bava.Domain.Commands.Contracts;

public interface ICommand
{
    public ValidationResult Validate();
}