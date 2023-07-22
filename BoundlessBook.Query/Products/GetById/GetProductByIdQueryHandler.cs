using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Products.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Products.GetById;

public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto>
{
    private readonly BoundlessBookContext _context;

    public GetProductByIdQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == request.ProductId, cancellationToken);

        if (product == null)
        {
            return null;
        }

        var model = product.Map();

        model = await model.SetCategories(_context);
        return model;
    }
}