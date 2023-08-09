using BoundlessBook.Common.Common.Query;
using BoundlessBook.Common.Common.Query.Filter;
using BoundlessBook.Domain.OrderAggregate.Enums;
using BoundlessBook.Domain.OrderAggregate.ValueObjects;
using BoundlessBook.Domain.OrderAggregate;
using BoundlessBook.Domain.SiteEntities;

namespace BoundlessBook.Query.Orders.DTOs;

public class OrderDto:BaseDto
{
    public Guid UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public OrderDiscount? OrderDiscount { get; set; }
    public OrderAddress? Address { get; set; }
    public ShippingMethod? ShippingMethod { get; set; }
    public DateTime LastUpdate { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
}

public class OrderItemDto : BaseDto
{
    public ProductOrderItem ProductOrderItem{ get; set; }
    public string ShopName { get; set; }
    public Guid OrderId { get; set; }
    public Guid InventoryId { get; set; }
    public int Count { get; set; }
    public float Price { get; set; }
    public float TotalPrice => Price * Count;
}

public class ProductOrderItem
{
    public string ProductTitle { get; set; }
    public string Slug { get; set; }
    public string ImageName { get; set; }
}
public class OrderFilterData : BaseDto
{
    public Guid UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public string? Shire { get; set; }
    public string? City { get; set; }
    public float TotalPrice { get; set; }
    public int TotalItemCount { get; set; }
    public string? ShippingType { get; set; }

}

public class OrderFilterParam : BaseFilterParam
{
    public Guid? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public OrderStatus? OrderStatus { get; set; }
}

public class OrderFilterResult : BaseFilter<OrderFilterData, OrderFilterParam>
{
    
}