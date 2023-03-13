using Blogger.Domain.Configuration;
using Blogger.Infra.Data.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Blogger.WebAPI.Configuration;

public static class ApplicationSetsConfiguration
{
    public static void AddApplicationSetsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<BloggerConfiguration>(configuration.GetSection(nameof(BloggerConfiguration)));
        services.AddDbContext<BloggerContext>(options =>
        {
            options.UseSqlServer(configuration.GetSection("BloggerConfiguration:BloggerSqlConnection").Value,  b => b.MigrationsAssembly("Blogger.WebAPI"));
        });
    }
}