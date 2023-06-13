using BoundlessBook.Common;
using BoundlessBook.Domain.OrderAggregate.Enums;
using BoundlessBook.Domain.OrderAggregate.ValueObjects;

namespace BoundlessBook.Domain.OrderAggregate;

public class Order:AggregateRoot
{
    public Guid UserId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public OrderDiscount? OrderDiscount { get; set; }
    public float TotalPrice => OrderItems.Sum(c => c.TotalPrice);
    public int ItemCount => OrderItems.Count();
    
    
    #region Relations

    public List<OrderItem> OrderItems { get; set; }
    
    #endregion
}