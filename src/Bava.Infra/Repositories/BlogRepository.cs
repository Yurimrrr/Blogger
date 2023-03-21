using Bava.Domain.Entities;
using Bava.Domain.Repositories;
using Bava.Infra.Context;
using Bava.Infra.Repositories.RepositoryBase;

namespace Bava.Infra.Repositories;

public class BlogRepository :  BaseRepository<Blog>, IBlogRepository
{
    public BlogRepository(BavaContext dbContext) : base(dbContext)
    {
    }
}