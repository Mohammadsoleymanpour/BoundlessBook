using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Sellers.AddInventory;

public class AddSellerInventoryCommand : IBaseCommand
{
    public AddSellerInventoryCommand(Guid sellerId, Guid productId, int count, float price, bool isActive, int? discountPercent)
    {
        SellerId = sellerId;
        ProductId = productId;
        Count = count;
        Price = price;
        IsActive = isActive;
        DiscountPercent = discountPercent;
    }
    public Guid SellerId { get; set; }
    public Guid ProductId { get; set; }
    public int Count { get; set; }
    public float Price { get; set; }
    public bool IsActive { get; set; }
    public int? DiscountPercent { get; set; }
}