using Bava.Domain.Entities;
using Bava.Domain.Repositories;
using Bava.Infra.Context;

namespace Bava.Infra.Repositories.RepositoryBase;

public class BaseRepository<T> : IBaseRepository<T>
    where T : Entity
{
    protected readonly BavaContext DbContext;

    public BaseRepository(BavaContext dbContext)
    {
        DbContext = dbContext;
    }

    public T? GetById(Guid id)
    {
        return DbContext.Find<T>(id);
    }

    public void Create(T t)
    {
        DbContext.Add(t);
        DbContext.SaveChanges();
    }

    public void Update(T t)
    {
        DbContext.Update(t);
        DbContext.SaveChanges();
    }

    public void Delete(T t)
    {
        DbContext.Remove(t);
        DbContext.SaveChanges();
    }
}