using Bava.Domain.Commands.UserCommands;
using Bava.Domain.Entities;
using Bava.Domain.Handlers;
using Bava.Domain.Handlers.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Bava.API.Controllers;

[ApiController]
[Route("v1/users")]
public class UserController : ControllerBase
{
    [Route("")]
    [HttpPost]
    public CommandResult<User> Create(
        [FromBody]CreateUserCommand command,
        [FromServices]UserHandler handler
    )
    {
        return handler.Handle(command);
    }
}