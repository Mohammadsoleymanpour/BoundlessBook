using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Products.DTOs;

namespace BoundlessBook.Query.Products.GetProductForShop;

public class GetProductForShopQuery : QueryFilter<ProductShopResult , ProductResultFilterParam>
{
    public GetProductForShopQuery(ProductResultFilterParam param) : base(param)
    {
    }
}