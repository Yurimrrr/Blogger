using FluentValidation.Results;
using MediatR;

namespace Blogger.Extensions.Domain.Messaging.Commands;

public abstract class Command : Message, IRequest<ValidationResult>
{
    public DateTime Timestamp { get; protected set; }
    public ValidationResult ValidationResult { get; protected set; }
    
    protected Command() =>
        (Timestamp, ValidationResult) = (DateTime.Now, new ValidationResult());
    
    public virtual bool IsValid()
    {
        return ValidationResult.IsValid;
    }
}