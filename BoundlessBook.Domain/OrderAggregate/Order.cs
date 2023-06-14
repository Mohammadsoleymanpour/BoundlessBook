using BoundlessBook.Common;
using BoundlessBook.Common.Exceptions;
using BoundlessBook.Domain.OrderAggregate.Enums;
using BoundlessBook.Domain.OrderAggregate.ValueObjects;

namespace BoundlessBook.Domain.OrderAggregate;

public class Order : AggregateRoot
{
    public Order()
    {

    }
    public Order(Guid userId)
    {
        UserId = userId;
        OrderStatus = OrderStatus.Pending;
    }
    public Guid UserId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public OrderDiscount? OrderDiscount { get; set; }
    public OrderAddress Address { get; set; }
    public DateTime LastUpdate { get; set; }
    public float TotalPrice => OrderItems.Sum(c => c.TotalPrice);
    public int ItemCount => OrderItems.Count();

    #region Relations

    public List<OrderItem> OrderItems { get; set; }

    #endregion

    public void AddItem(OrderItem item)
    {
        OrderItems.Add(item);
    }

    public void RemoveItem(Guid itemId)
    {
        var item = OrderItems.FirstOrDefault(c => c.Id == itemId);
        if (item ==null)
        {
            throw new NullOrEmptyDomainException("آبتمی برای حذف یافت نشد");
        }

        OrderItems.Remove(item);
    }

    public void ChangeItemCount(Guid itemId, int count)
    {
        var item = OrderItems.FirstOrDefault(c => c.Id == itemId);
        if (item == null)
        {
            throw new NullOrEmptyDomainException("آیتمی یافت نشد");
        }

        item.ChangeCount(count);
    }

    public void ChangeStatus(OrderStatus status)
    {
        OrderStatus = status;
        LastUpdate = DateTime.Now;
    }

    public void CheckOutAddress(OrderAddress address)
    {
        Address = address;
    }
}