using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Seller.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Seller.GetById;

public class GetSellerByIdQueryHandler : IQueryHandler<GetSellerByIdQuery, SellerDto>
{
    private readonly BoundlessBookContext _context;

    public GetSellerByIdQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<SellerDto> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await _context.Sellers.FirstOrDefaultAsync(c => c.Id == request.SellerId, cancellationToken);
        if (seller == null)
        {
            return null;
        }

        return seller.Map();
    }
}