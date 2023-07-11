using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Sellers.EditInventory;

public class EditSellerInventoryCommand:IBaseCommand
{
    public EditSellerInventoryCommand(Guid inventoryId, Guid sellerId, int count, float price, bool isActive, int? discountPercent)
    {
        InventoryId = inventoryId;
        SellerId = sellerId;
        Count = count;
        Price = price;
        IsActive = isActive;
        DiscountPercent = discountPercent;
    }
    public Guid InventoryId { get; set; }
    public Guid SellerId { get; set; }
    public int Count { get; set; }
    public float Price { get; set; }
    public bool IsActive { get; set; }
    public int? DiscountPercent { get; set; }
}