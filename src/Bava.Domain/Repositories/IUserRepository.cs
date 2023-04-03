using Bava.Domain.Entities;

namespace Bava.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    public User? GetByEmail(string email);
}