using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Orders.DTOs;

namespace BoundlessBook.Query.Orders.GetById;

public class GetOrderByIdQuery : IQuery<OrderDto>
{
    public Guid OrderId { get; set; }
}