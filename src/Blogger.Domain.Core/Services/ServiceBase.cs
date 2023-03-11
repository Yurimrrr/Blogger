using System.Linq.Expressions;
using Blogger.Extensions.Data.Core.Interfaces;
using Blogger.Extensions.Domain;

namespace Blogger.Domain.Core.Services;

public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : IEntity
{
    private readonly IRepositoryCommandBase<TEntity> _repositoryCommandBase;
    
    protected IRepositoryCommandBase<TEntity> RepositoryCommandBase => _repositoryCommandBase;
    
    public ServiceBase(IRepositoryCommandBase<TEntity> repositoryCommandBase) =>
        (_repositoryCommandBase) = (repositoryCommandBase);

    public virtual (bool IsSuccess, bool IsExist, TEntity? Entity) IsExists(
        Expression<Func<TEntity, bool>> predicate) => _repositoryCommandBase.IsExists(predicate);
    
    public virtual TEntity Insert(TEntity entity) => _repositoryCommandBase.Insert(entity);
    
    public virtual TEntity Update(TEntity entity) => _repositoryCommandBase.Update(entity);
    
    public virtual bool Delete(TEntity entity) => _repositoryCommandBase.Delete(entity);
    
    public virtual bool Delete(object key) => _repositoryCommandBase.Delete(key);
    
    public void Dispose()
    {
        _repositoryCommandBase?.Dispose();
        GC.SuppressFinalize(this);
    }
    
}