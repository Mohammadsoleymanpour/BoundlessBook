using BoundlessBook.Domain.CategoryAggregate;
using BoundlessBook.Infrastructure._Utilities;

namespace BoundlessBook.Infrastructure.Ef.Persistent.CategoryAggregate;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(BoundlessBookContext context) : base(context)
    {
    }
}