using Blogger.Extensions.Mediator;
using Blogger.Infra.Data.EFCore.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Infra.CrossCutting.IoC;

public class NativeInjectorBootStrapper
{
    public static void RegisterService(IServiceCollection services)
    {
        services.AddScoped<IMediatorHandler, MediatorHandler>();

        // services.AddSingleton<JwtSettings>();
        // services.AddScoped<IJwtService, JwtService>();
        // services.AddScoped<AuthenticatedUser>();

        

        services.AddScoped<BloggerContext>();

        
    }
}