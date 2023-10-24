namespace BoundlessBook.Query.Seller.DTOs;

public class InventoryDto
{
    public Guid SellerId { get; set; }
    public string ShopName { get; set; }
    public Guid ProductId { get; set; }
    public string ProductTitle { get; set; }
    public string ProductImage { get; set; }
    public int Count { get; set; }
    public float Price { get; set; }
    public int DiscountPercentage { get; set; }
}