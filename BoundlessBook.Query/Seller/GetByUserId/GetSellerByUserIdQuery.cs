using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Seller.DTOs;

namespace BoundlessBook.Query.Seller.GetByUserId;

public record GetSellerByUserIdQuery(Guid UserId):IQuery<SellerDto>;