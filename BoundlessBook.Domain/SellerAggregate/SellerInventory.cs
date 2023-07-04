using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Exceptions;

namespace BoundlessBook.Domain.SellerAggregate;

public class SellerInventory:BaseEntity
{
    public SellerInventory( Guid productId, int count, float price)
    {
        if (count<1)
        {
            throw new InvalidDomainException(" تعداد نمیتواند کمتر از یک باشد");
        }
        ProductId = productId;
        Count = count;
        Price = price;
       
    }
    public Guid SellerId { get; set; }
    public Guid ProductId { get; set; }
    public int Count { get; set; }
    public float Price { get; set; }
    public bool IsActive { get; set; }



}