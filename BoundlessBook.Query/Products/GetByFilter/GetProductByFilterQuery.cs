using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Products.DTOs;

namespace BoundlessBook.Query.Products.GetByFilter;

public class GetProductByFilterQuery:QueryFilter<ProductFilterResult,ProductFilterParams>
{
    public GetProductByFilterQuery(ProductFilterParams param) : base(param)
    {
    }
}