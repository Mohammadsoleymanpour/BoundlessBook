using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Categories.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Categories.GetList;

public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, List<CategoryDto>>
{
    private readonly BoundlessBookContext _context;

    public GetCategoriesQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _context.Categories.OrderByDescending(c => c.CreationDate).ToListAsync(cancellationToken);
        return categories.Map();
    }
}