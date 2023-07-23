using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Seller.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Seller.GetByFilter;

public class GetSellersQueryHandler : IQueryHandler<GetSellersQuery, SellerFilterResult>
{
    private readonly BoundlessBookContext _context;

    public GetSellersQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<SellerFilterResult> Handle(GetSellersQuery request, CancellationToken cancellationToken)
    {
        var @param = request.FilterParam;
        var result = _context.Sellers.OrderByDescending(c => c.CreationDate).AsQueryable();

        if (string.IsNullOrEmpty(param.NationalCode) is false)
        {
            result = result.Where(c => c.NationalCode.Contains(param.NationalCode));
        }

        if (string.IsNullOrEmpty(param.ShpeName) is false)
        {
            result = result.Where(c => c.ShopName.Contains(param.ShpeName));
        }

        var skip = (param.PageId - 1) * param.Take;

        var model = new SellerFilterResult()
        {
            FilterParams = @param,
            Data = await result.Select(c => c.Map()).ToListAsync(cancellationToken),
        };
        model.GeneratePaging(result, param.Take, param.PageId);

        return model;
    }
}