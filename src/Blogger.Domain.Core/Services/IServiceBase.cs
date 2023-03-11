using System.Linq.Expressions;
using Blogger.Extensions.Domain;

namespace Blogger.Domain.Core.Services;

public interface IServiceBase
{
    
}

public interface IServiceBase<TEntity> : IDisposable where TEntity : IEntity
{
    (bool IsSuccess, bool IsExist, TEntity? Entity) IsExists(Expression<Func<TEntity, bool>> predicate);
    TEntity Insert(TEntity entity);
    TEntity Update(TEntity entity);
    bool Delete(TEntity entity);
    bool Delete(object key);
}
