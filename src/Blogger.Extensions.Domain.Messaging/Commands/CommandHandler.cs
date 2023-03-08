using Blogger.Extensions.Data.Core.Interfaces;
using FluentValidation.Results;

namespace Blogger.Extensions.Domain.Messaging.Commands;

public abstract class CommandHandler : CommandResult
{
    protected async Task<ValidationResult> Commit(IUnitOfWork uow, string message)
    {
        if (!await uow.SaveEntitiesAsync())
            AddError(message);

        return this;
    }

    protected async Task<ValidationResult> Commit(IUnitOfWork uow)
    {
        return await Commit(uow, "There was an error saving data").ConfigureAwait(false);
    }
}