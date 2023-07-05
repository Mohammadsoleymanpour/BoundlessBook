using System.Diagnostics.Metrics;
using System.Runtime;
using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.Exceptions;

namespace BoundlessBook.Domain.OrderAggregate;

public class OrderItem:BaseEntity
{
    public OrderItem( Guid inventoryId, int count, float price)
    {
        InventoryId = inventoryId;
        Count = count;
        Price = price;
    }
    public Guid OrderId { get; set; }
    public Guid InventoryId { get; set; }
    public int Count { get; set; }
    public float Price { get; set; }
    public float TotalPrice => Price * Count;

    public void ChangeCount(int count)
    {
        CountGuard(count);
        Count = count;
    }

    public void SetPrice(float price)
    {
        PriceGuard(price);
        Price = price;
    }

    public void PriceGuard(float price)
    {
        if (price<1)
        {
            throw new InvalidDomainException("قیمت وارد شده معتبر نمیباشد");
        }
    }

    public void CountGuard(int count)
    {
        if (count < 1)
        {
            throw new InvalidDomainException("تعداد وارد شده معتبر نیست");
        }
    }
}