using Bava.Domain.Entities;
using Bava.Domain.Repositories;
using Bava.Infra.Context;
using Bava.Infra.Repositories.RepositoryBase;

namespace Bava.Infra.Repositories;

public class PostRepository :  BaseRepository<Post>, IPostRepository
{
    public PostRepository(BavaContext dbContext) : base(dbContext)
    {
    }
}