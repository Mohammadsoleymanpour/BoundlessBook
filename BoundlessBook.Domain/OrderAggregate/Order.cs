﻿using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.Exceptions;
using BoundlessBook.Domain.OrderAggregate.Enums;
using BoundlessBook.Domain.OrderAggregate.ValueObjects;
using BoundlessBook.Domain.SiteEntities;

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
    public OrderAddress? Address { get; set; }
    public ShippingMethod? ShippingMethod { get; set; }
    public DateTime LastUpdate { get; set; }

    public float TotalPrice
    {
        get
        {
            var totalItemPrice = OrderItems.Sum(c => c.TotalPrice);
            if (ShippingMethod != null)
            {
                totalItemPrice += ShippingMethod.Cost;
            }

            if (OrderDiscount != null)
            {
                totalItemPrice -= OrderDiscount.DiscountAmount;
            }

            return 0;
        }
    }

    public int ItemCount => OrderItems.Count();

    #region Relations

    public List<OrderItem> OrderItems { get; set; }

    #endregion

    public void AddItem(OrderItem item)
    {
        Guard();

        var oldItem = OrderItems.FirstOrDefault(c => c.InventoryId == item.InventoryId);
        if (oldItem != null)
        {
            oldItem.ChangeCount(item.Count + oldItem.Count);
            return;
        }
        OrderItems.Add(item);
    }

    public void RemoveItem(Guid itemId)
    {
        Guard();
        var item = OrderItems.FirstOrDefault(c => c.Id == itemId);
        if (item == null)
        {
            throw new NullOrEmptyDomainException("آبتمی برای حذف یافت نشد");
        }

        OrderItems.Remove(item);
    }

    public void IncreaseItemCount(Guid itemId, int count)
    {
        var item = OrderItems.FirstOrDefault(c => c.Id == itemId);
        if (item == null)
        {
            throw new NullOrEmptyDomainException("آیتمی یافت نشد");
        }
        item.IncreaseCount(count);
    }
     
    public void DecreaseItemCount(Guid itemId, int count)
    {
        var item = OrderItems.FirstOrDefault(c => c.Id == itemId);
        if (item == null)
        {
            throw new NullOrEmptyDomainException("آیتمی یافت نشد");
        }
        item.IncreaseCount(count);
    }
    public void ChangeItemCount(Guid itemId, int count)
    {
        var item = OrderItems.FirstOrDefault(c => c.Id == itemId);
        if (item == null)
        {
            throw new NullOrEmptyDomainException("آیتمی یافت نشد");
        }

        item.DeCreaseCount(count);
    }

    public void ChangeStatus(OrderStatus status)
    {
        OrderStatus = status;
        LastUpdate = DateTime.Now;
    }

    public void CheckOutAddress(OrderAddress address)
    {
        Guard();
        Address = address;
    }

    public void Guard()
    {
        if (OrderStatus != OrderStatus.Pending)
        {
            throw new InvalidDomainException("امکان ویرایش این سفارش وجود ندارد");
        }
    }
}