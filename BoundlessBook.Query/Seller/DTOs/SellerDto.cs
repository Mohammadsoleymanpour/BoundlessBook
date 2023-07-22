using BoundlessBook.Common.Common.Query;
using BoundlessBook.Common.Common.Query.Filter;
using BoundlessBook.Domain.SellerAggregate.Enums;

namespace BoundlessBook.Query.Seller.DTOs;

public class SellerDto : BaseDto
{
    public Guid UserId { get; set; }
    public string ShopeName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus SellerStatus { get; set; }
}

public class SellerFilterResult : BaseFilter<SellerDto,SellerFilterParam>
{

}

public class SellerFilterParam : BaseFilterParam
{
    public string ShpeName { get; set; }
    public string NationalCode { get; set; }
}