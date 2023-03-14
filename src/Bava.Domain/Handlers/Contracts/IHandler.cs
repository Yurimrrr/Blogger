using Bava.Domain.Commands.Contracts;
using Bava.Domain.Entities;

namespace Bava.Domain.Handlers.Contracts;

/*
 * TC: Handler Command
 */
public interface IHandler <in TC> where TC : ICommand
{
    public CommandResult Handle(TC command);
}

/*
 * TC: Handler Command
 * TR: Handler Return Type
 */
public interface IHandler <in TC, TR> where TC : ICommand where TR : Entity
{
    public CommandResult<TR> Handle(TC command);
}