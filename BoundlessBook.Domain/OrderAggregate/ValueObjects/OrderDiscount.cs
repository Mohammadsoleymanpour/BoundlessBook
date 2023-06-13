using BoundlessBook.Common;

namespace BoundlessBook.Domain.OrderAggregate.ValueObjects;

public class OrderDiscount:ValueObject
{
    public OrderDiscount(string discountTitle, float discountAmount)
    {
        DiscountTitle = discountTitle;
        DiscountAmount = discountAmount;
    }
    public string DiscountTitle { get; set; }
    public float DiscountAmount { get; set; }
}