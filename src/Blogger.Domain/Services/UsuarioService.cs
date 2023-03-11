using Blogger.Domain.Core.Services;
using Blogger.Domain.Entities;
using Blogger.Domain.Interfaces.Services;
using Blogger.Extensions.Data.Core.Interfaces;

namespace Blogger.Domain.Services;

public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
{
    public UsuarioService(IRepositoryCommandBase<Usuario> repositoryCommandBase) : base(repositoryCommandBase)
    {
    }
}