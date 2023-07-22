using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Seller.DTOs;

namespace BoundlessBook.Query.Seller.GetList;

public class GetSellersQuery : QueryFilter<SellerFilterResult,SellerFilterParam>
{
    public GetSellersQuery(SellerFilterParam param) : base(param)
    {
    }
};
