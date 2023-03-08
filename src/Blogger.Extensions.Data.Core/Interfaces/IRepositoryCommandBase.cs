using System.Linq.Expressions;
using Blogger.Extensions.Domain;

namespace Blogger.Extensions.Data.Core.Interfaces;

public interface IRepositoryCommandBase<TEntity> : IDisposable where TEntity : IEntity
{
    IUnitOfWork UnitOfWork { get; }
    (bool, bool, TEntity? entity) IsExists(Expression<Func<TEntity, bool>> predicate);
    TEntity Insert(TEntity entity);
    Task<TEntity> InsertAsync(TEntity entity);
    TEntity Update(TEntity entity);
    bool Delete(TEntity entity);
    bool Delete(object key);
}