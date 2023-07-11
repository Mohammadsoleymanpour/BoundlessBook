using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Sellers.Create;

public class CreateSellerCommand:IBaseCommand
{
    public CreateSellerCommand(Guid userId, string shopName, string nationalCode)
    {
        UserId = userId;
        ShopName = shopName;
        NationalCode = nationalCode;
    }
    public Guid UserId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }

}