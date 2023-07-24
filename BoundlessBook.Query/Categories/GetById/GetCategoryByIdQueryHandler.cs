using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Categories.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Categories.GetById;

public class GetCategoryByIdQueryHandler:IQueryHandler<GetCategoryByIdQuery,CategoryDto>
{
    private readonly BoundlessBookContext _context;

    public GetCategoryByIdQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.Include(c=>c.Child).ThenInclude(c=>c.Child).FirstOrDefaultAsync(c => c.Id == request.CategoryId,cancellationToken);
        return category.Map();
    }
}