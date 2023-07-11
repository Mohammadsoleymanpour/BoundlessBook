using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.Exceptions;

namespace BoundlessBook.Domain.SellerAggregate;

public class SellerInventory:BaseEntity
{
    public SellerInventory( Guid productId, int count, float price, int? discountPercent)
    {
        if (count < 1)
        {
            throw new InvalidDomainException(" تعداد نمیتواند کمتر از یک باشد");
        }
        ProductId = productId;
        Count = count;
        Price = price;
        DiscountPercent = discountPercent;
    }
    public Guid SellerId { get; set; }
    public Guid ProductId { get; set; }
    public int Count { get; set; }
    public float Price { get; set; }
    public bool IsActive { get; set; }
    public int?  DiscountPercent { get; set; }

    public void Edit(int count, float price, int? discountPercent)
    {
        if (count < 1)
        {
            throw new InvalidDomainException(" تعداد نمیتواند کمتر از یک باشد");
        }
        Count = count;
        Price = price;
        DiscountPercent = discountPercent; 
    }
}