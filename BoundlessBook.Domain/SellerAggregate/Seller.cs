using BoundlessBook.Common;
using BoundlessBook.Domain.SellerAggregate.Enums;

namespace BoundlessBook.Domain.SellerAggregate;

public class Seller:AggregateRoot
{
    public Guid UserId { get; set; }

    public string ShopName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus SellerStatus { get; set; }
    public List<SellerInventory> SellerInventories { get; set; }

}