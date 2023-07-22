using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Products.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Products.GetByFilter;

public class GetProductByFilterQueryHandler : IQueryHandler<GetProductByFilterQuery, ProductFilterResult>
{
    private readonly BoundlessBookContext _context;

    public GetProductByFilterQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<ProductFilterResult> Handle(GetProductByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParam;

        var result = _context.Products.OrderByDescending(c => c.CreationDate).AsQueryable();

        if (@params.Id != null)
        {
            result = result.Where(c => c.Id == @params.Id);
        }

        if (string.IsNullOrEmpty(@params.Slug) is false)
        {
            result = result.Where(c => c.Slug == @params.Slug);
        }

        if (string.IsNullOrEmpty(@params.Title) is false)
        {
            result = result.Where(c => c.Title.Contains(@params.Title));
        }
         
        var skip = (@params.PageId - 1) * @params.Take;

        var model = new ProductFilterResult()
        {
            FilterParams = @params,
            Data = await result.Skip(skip).Take(@params.Take).Select(c => c.MapListData())
                .ToListAsync(cancellationToken)
        };

        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}   