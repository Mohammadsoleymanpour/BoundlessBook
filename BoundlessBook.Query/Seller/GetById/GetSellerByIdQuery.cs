using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Seller.DTOs;

namespace BoundlessBook.Query.Seller.GetById;

public class GetSellerByIdQuery : IQuery<SellerDto>
{
    public GetSellerByIdQuery(Guid sellerId)
    {
        SellerId = sellerId;
    }
    public Guid SellerId { get;private set; }
    
}