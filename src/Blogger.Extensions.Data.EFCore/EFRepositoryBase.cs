using System.Linq.Expressions;
using Blogger.Extensions.Core.Domain.Abstractions.DomainObjects;
using Blogger.Extensions.Data.Core.Helpers.Pagination;
using Blogger.Extensions.Data.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Extensions.Data.EFCore;

public class EFRepositoryBase<TContext, TEntity> : IRepositoryBase<TEntity>
    where TContext : DbContext
    where TEntity : Entity
{
    protected readonly TContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public EFRepositoryBase(TContext context) =>
        (Context, DbSet) = (context, context.Set<TEntity>());
    
    public IUnitOfWork UnitOfWork => (IUnitOfWork) Context;
    
    public virtual IQueryable<TEntity> GetAll() => Context.Set<TEntity>();

    public virtual TEntity? Find(params object[] keyValues) => Context.Set<TEntity>().Find(keyValues);
    
    public virtual async Task<TEntity?> FindAsync(params object[] keyValues) => 
        await Context.Set<TEntity>().FindAsync(keyValues);
    
    public virtual TEntity? FindOne(Expression<Func<TEntity, bool>> predicate) => 
        Context.Set<TEntity>().FirstOrDefault(predicate);
    
    public virtual async Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate) =>
        await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    
    public virtual IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate) =>
        Context.Set<TEntity>().Where(predicate);
    
    public virtual async Task<IList<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate) =>
        await Context.Set<TEntity>().Where(predicate).ToListAsync();

    public (bool, bool, TEntity? entity) IsExists(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = FindOne(predicate);
        return entity == null ? (true, false, null) : (true, true, entity);
    }
    
    public virtual TEntity Insert(TEntity entity)
    {
        var result = DbSet.Add(entity);
        return result.Entity;
    }
    
    public virtual async Task<TEntity> InsertAsync(TEntity entity)
    {
        var result = await DbSet.AddAsync(entity);
        return result.Entity;
    }

    public virtual TEntity Update(TEntity entity)
    {
        var result = DbSet.Update(entity);
        return result.Entity;
    }

    public bool Delete(TEntity entity)
    {
        DbSet.Remove(entity);
        return true;
    }

    public bool Delete(object key)
    {
        var item = DbSet.Find(key);
        return item != null && Delete(item);
    }

    public void Dispose()
    {
        Context?.Dispose();
        GC.SuppressFinalize(this);
    }
}