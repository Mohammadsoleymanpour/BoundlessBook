using BoundlessBook.Common;

namespace BoundlessBook.Domain.OrderAggregate.ValueObjects;

public class ShippingMethod: ValueObject
{
    public ShippingMethod(string shippingType, float shippingCost)
    {
        ShippingType = shippingType;
        ShippingCost = shippingCost;
    }
    public string  ShippingType { get; set; }
    public float ShippingCost { get; set; }
}