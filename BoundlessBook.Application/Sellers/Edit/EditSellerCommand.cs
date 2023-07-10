using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Sellers.Edit;

public class EditSellerCommand:IBaseCommand
{
    public EditSellerCommand(Guid sellerId, string shopName, string nationalCode)
    {
        SellerId = sellerId;
        ShopName = shopName;
        NationalCode = nationalCode;
    }
    public Guid SellerId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; } 
}