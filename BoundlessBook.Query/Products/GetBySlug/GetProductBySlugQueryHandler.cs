using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Products.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Products.GetBySlug;

public class GetProductBySlugQueryHandler : IQueryHandler<GetProductBySlugQuery, ProductDto>
{
    private readonly BoundlessBookContext _context;

    public GetProductBySlugQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<ProductDto> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(c => c.Slug == request.Slug, cancellationToken);
        if (product == null)
        {
            return null;
        }

        var model = product.Map();
        model = await model.SetCategories(_context);

        return model;
    }
}