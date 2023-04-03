using Bava.Domain.Entities;

namespace Bava.Domain.Repositories;

public interface IBaseRepository<T>
    where T : Entity
{
    T? GetById(Guid id);
    void Create(T t);
    void Update(T t);
    void Delete(T t);
}