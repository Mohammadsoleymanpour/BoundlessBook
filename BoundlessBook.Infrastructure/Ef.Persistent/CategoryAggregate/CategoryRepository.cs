using BoundlessBook.Domain.CategoryAggregate;
using BoundlessBook.Infrastructure._Utilities;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Infrastructure.Ef.Persistent.CategoryAggregate;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    private readonly BoundlessBookContext _context;
    public CategoryRepository(BoundlessBookContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsExistProduct(Guid categoryId)
    {
      return await _context.Products.AnyAsync(c =>
            c.CategoryId == categoryId || c.SubCategoryId == categoryId || c.SecondarySubCategoryId == categoryId);
    }
}