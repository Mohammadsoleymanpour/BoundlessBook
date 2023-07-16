using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Orders.DTOs;

namespace BoundlessBook.Query.Orders.GetByFilter;

public class GetOrderByFilterQuery:QueryFilter<OrderFilterResult,OrderFilterParam>
{
    public GetOrderByFilterQuery(OrderFilterParam param) : base(param)
    {
    }
}