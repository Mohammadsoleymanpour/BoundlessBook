using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Seller.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Seller.GetByUserId;

public class GetSellerByUserIdQueryHandler : IQueryHandler<GetSellerByUserIdQuery, SellerDto>
{
    private readonly BoundlessBookContext _context;

    public GetSellerByUserIdQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<SellerDto> Handle(GetSellerByUserIdQuery request, CancellationToken cancellationToken)
    {
        var currentSeller = await _context.Sellers.FirstOrDefaultAsync(c => c.UserId == request.UserId,cancellationToken);
        if (currentSeller == null)
        {
            return null;
        }

        return currentSeller.Map();
    }
}