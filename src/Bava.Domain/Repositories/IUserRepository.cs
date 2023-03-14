using Bava.Domain.Entities;

namespace Bava.Domain.Repositories;

public interface IUserRepository
{
    public User? GetById(Guid Id);
    public User? GetByEmail(string Email);
    public void Create(User user);
    public void Update(User user);
    public void Delete(User user);
}