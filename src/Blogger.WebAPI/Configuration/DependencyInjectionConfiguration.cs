using Domain.Infra.CrossCutting.IoC;

namespace Blogger.WebAPI.Configuration;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        NativeInjectorBootStrapper.RegisterService(services);
    }
}