using Bava.Domain.Entities;
using Bava.Domain.Repositories;
using Bava.Infra.Context;
using Bava.Infra.Repositories.RepositoryBase;

namespace Bava.Infra.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(BavaContext dbContext) : base(dbContext)
    {
    }

    public User? GetByEmail(string email)
    {
        return DbContext.Users.FirstOrDefault(x => x.Email == email);
    }
}