using Bava.Domain.Commands.UserCommands;
using Bava.Domain.Entities;
using Bava.Domain.Handlers.Contracts;
using Bava.Domain.Repositories;

namespace Bava.Domain.Handlers;

public class UserHandlers : IHandler<CreateUserCommand, User>
{
    private readonly IUserRepository _userRepository;
    
    public UserHandlers(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public CommandResult<User> Handle(CreateUserCommand command)
    {
        var validation = command.Validate();
        if (!validation.IsValid)
        {
            return new CommandResult<User>(Status.Invalid, "Usuário inválido!");
        }

        var user = _userRepository.GetByEmail(command.Email);
        if (user != null)
        {
            return new CommandResult<User>(Status.Invalid, "Usuário inválido!");
        }

        user = new User
        {
            Email = command.Email,
            Name = command.Name,
            Password = command.Password,
        };
        
        _userRepository.Create(user);

        return new CommandResult<User>(Status.Created, "Usuário criado com sucesso!", user);
    }
}