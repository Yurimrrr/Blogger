using Blogger.Domain.Entities;
using Blogger.Extensions.Mediator;
using Blogger.Infra.Data.EFCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Infra.Data.EFCore.Contexts;

public class BloggerContext : DbContextBase<BloggerContext>
{
    public const string DEFAULT_SCHEMA = "dbo";
    
    #region DbSets
    public DbSet<Usuario> Usuario { get; set; }
    #endregion
    
    //public NExpertsContext(DbContextOptions<NExpertsContext> contextOptions, 
    //    IMediatorHandler mediatorHandler) : base(contextOptions, mediatorHandler)
   // {
    //}
    public BloggerContext(DbContextOptions<BloggerContext> contextOptions) : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(new UsuarioMapConfiguration().Configure);
        
        base.OnModelCreating(modelBuilder);
    }
}