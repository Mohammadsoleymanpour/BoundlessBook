using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Categories.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Categories.GetByParentId;

public class GetCategoriesByParentIdQueryHandler : IQueryHandler<GetCategoriesByParentIdQuery, List<ChildCategoryDto>>
{
    private readonly BoundlessBookContext _context;

    public GetCategoriesByParentIdQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<List<ChildCategoryDto>> Handle(GetCategoriesByParentIdQuery request, CancellationToken cancellationToken)
    {
        var childsCategory = await _context.Categories.Where(c => c.ParentId == request.ParentId)
            .ToListAsync(cancellationToken);

        return childsCategory.MapChild();
    }
}