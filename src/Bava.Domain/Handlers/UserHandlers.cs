using Bava.Domain.Commands.UserCommands;
using Bava.Domain.Entities;
using Bava.Domain.Handlers.Contracts;
using Bava.Domain.Repositories;
using Bava.Domain.Utils;

namespace Bava.Domain.Handlers;

public class UserHandler : IHandler<CreateUserCommand, User>, IHandler<LoginUserCommand, User>
{
    private readonly IUserRepository _userRepository;

    private readonly IBlogRepository _blogRepository;
    private readonly IHasher _hasher;

    public UserHandler
        (IUserRepository userRepository, IBlogRepository blogRepository, IHasher hasher) =>
        (_userRepository, _blogRepository, _hasher) =
        (userRepository, blogRepository, hasher);

    public CommandResult<User> Handle(CreateUserCommand command)
    {
        var validation = command.Validate();
        if (!validation.IsValid)
        {
            return new CommandResult<User>(Status.Invalid, "Usuário inválido!");
        }

        if (_userRepository.GetByEmail(command.Email) != null)
        {
            return new CommandResult<User>(Status.Invalid, "Usuário inválido!");
        }

        var user = User.Create(command.Name, command.Email, command.Password);

        _userRepository.Create(user);

        var blog = Blog.Create(user.Id);

        _blogRepository.Create(blog);

        return new CommandResult<User>(Status.Created, "Usuário criado com sucesso!", user);
    }

    public CommandResult<User> Handle(LoginUserCommand command)
    {
        var validation = command.Validate();
        if (!validation.IsValid)
        {
            return new CommandResult<User>(Status.Invalid, "Dados de login inválidos!");
        }

        var user = _userRepository.GetByEmail(command.Email);
        if (user == null || _hasher.Validate(command.Password, user.Password))
        {
            return new CommandResult<User>(Status.NotFound, "Usuário ou senha inválidos!");
        }

        return new CommandResult<User>(Status.Ok, "Logado com sucesso!", user);
    }
}