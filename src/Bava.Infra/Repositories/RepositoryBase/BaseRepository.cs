using Bava.Domain.Entities;
using Bava.Domain.Repositories;
using Bava.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Bava.Infra.Repositories.RepositoryBase;

public class BaseRepository<T> : IBaseRepository<T>
    where T : Entity
{
    private readonly BavaContext _dbContext;
    private  DbSet<T> _dbSet;

    public BaseRepository(BavaContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }
    
    public T? GetById(Guid id)
    {
        return _dbSet.Find(id);
    }

    public T? GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public void Create(T t)
    {
        _dbSet.Add(t);
        _dbContext.SaveChanges();
    }

    public void Update(T t)
    {
        _dbSet.Update(t);
        _dbContext.SaveChanges();
    }

    public void Delete(T t)
    {
        _dbSet.Remove(t);
        _dbContext.SaveChanges();
    }
}