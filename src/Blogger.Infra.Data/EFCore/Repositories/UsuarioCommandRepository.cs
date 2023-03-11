using Blogger.Domain.Entities;
using Blogger.Domain.Interfaces.Repositories.Commands;
using Blogger.Extensions.Data.Core.Base;
using Blogger.Infra.Data.EFCore.Contexts;

namespace Blogger.Infra.Data.EFCore.Repositories;

public class UsuarioCommandRepository : RepositoryCommandBase<BloggerContext, Usuario>, IUsuarioCommandRepository
{
    public UsuarioCommandRepository(BloggerContext context) : base(context) { }
}