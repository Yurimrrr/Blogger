using System.Linq.Expressions;
using Blogger.Extensions.Data.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Blogger.Extensions.Domain;

namespace Blogger.Extensions.Data.Core.Base;

public abstract class RepositoryCommandBase<TContext, TEntity> : IRepositoryCommandBase<TEntity>
        where TContext : DbContext
        where TEntity : class, IEntity
{
    protected readonly TContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public RepositoryCommandBase(TContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public IUnitOfWork UnitOfWork => (IUnitOfWork) Context;

    public virtual (bool, bool, TEntity? entity) IsExists(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = DbSet.FirstOrDefault(predicate);
        return entity != null 
            ? (true, true, entity) 
            : (true, false, null);
    }

    public virtual TEntity Insert(TEntity entity)
    {
        try
        {
            var result = DbSet.Add(entity);
            Context.SaveChanges();
            return result.Entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public virtual async Task<TEntity> InsertAsync(TEntity entity)
    {
        var result = await DbSet.AddAsync(entity); 
        Context.SaveChanges();
        return result.Entity;
    }

    public virtual TEntity Update(TEntity entity)
    {
        var result = DbSet.Update(entity);
        Context.SaveChanges(); 
        return result.Entity;
    }

    public virtual bool Delete(TEntity entity)
    {
        DbSet.Remove(entity);
        Context.SaveChanges();
        return true;
    }

    public virtual bool Delete(object key)
    {
        var item = DbSet.Find(key);
        Context.SaveChanges();
        return item != null && Delete(item);
    }

    public void Dispose()
    {
        //Context?.Dispose();
        //GC.SuppressFinalize(this);
    }
}