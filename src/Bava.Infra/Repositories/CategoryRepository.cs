using Bava.Domain.Entities;
using Bava.Domain.Repositories;
using Bava.Infra.Context;
using Bava.Infra.Repositories.RepositoryBase;

namespace Bava.Infra.Repositories;

public class CategoryRepository :  BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(BavaContext dbContext) : base(dbContext)
    {
    }
}