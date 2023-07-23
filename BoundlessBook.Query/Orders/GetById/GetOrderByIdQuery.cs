using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Orders.DTOs;

namespace BoundlessBook.Query.Orders.GetById;

public class GetOrderByIdQuery : IQuery<OrderDto>
{
    public GetOrderByIdQuery(Guid orderId)
    {
        OrderId = orderId;
    }
    public Guid OrderId { get;private set; }
}