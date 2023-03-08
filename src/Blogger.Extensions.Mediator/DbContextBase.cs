using Blogger.Extensions.Data.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Extensions.Mediator;

public class DbContextBase<TContext> : DbContext, IUnitOfWork where TContext : DbContext
{
    protected readonly IMediatorHandler MediatorHandler;
    
    //public DbContextBase(DbContextOptions<TContext> contextOptions,
    //    IMediatorHandler mediatorHandler) : base(contextOptions) => MediatorHandler = mediatorHandler;
    public DbContextBase(DbContextOptions<TContext> contextOptions) : base(contextOptions)
    {
    
    }
    
    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        //await MediatorHandler.DispatchDomainEventsAsync(this);
        return await SaveChangesAsync(cancellationToken) > 0;
    }
}