using Blogger.Application.Base;
using Blogger.Application.Interfaces;
using Blogger.Application.ViewModels;
using Blogger.Domain.Interfaces.Configuration;
using Blogger.Domain.Interfaces.Repositories.Queries;
using Blogger.Extensions.Mediator;
using FluentValidation.Results;
using Microsoft.Extensions.Options;

namespace Blogger.Application.Services;

public class UsuarioAppService : AppServiceBase, IUsuarioAppService
{
    private readonly IBloggerConfiguration _configuration;
    private readonly IUsuarioQueryRepository _usuarioQueryRepository;
    
    public UsuarioAppService(IOptions<IBloggerConfiguration> configuration,
        IUsuarioQueryRepository usuarioQueryRepository,
        IMediatorHandler mediator) : base(mediator) =>
        (_configuration, _usuarioQueryRepository) = 
        (configuration.Value, usuarioQueryRepository);
    
    public async Task<int> GetIdPerfilUsuario(int idUsuario)
    {
        // var perfil = await _usuarioQueryRepository.GetPerfilByUsuarioId<PerfilViewModel>(idUsuario);

        // return perfil.Id.ToInt();
        return 0;
    }
    
}