using Blogger.Application.Base;
using Blogger.Application.ViewModels;
using FluentValidation.Results;

namespace Blogger.Application.Interfaces;

public interface IUsuarioAppService : IAppServiceBase
{
    Task<int> GetIdPerfilUsuario(int idUsuario);
}