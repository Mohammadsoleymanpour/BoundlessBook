using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.SellerAggregate.Enums;

namespace BoundlessBook.Application.Sellers.Edit;

public class EditSellerCommand : IBaseCommand
{
    public EditSellerCommand(Guid sellerId, string shopName, string nationalCode, SellerStatus status)
    {
        SellerId = sellerId;
        ShopName = shopName;
        NationalCode = nationalCode;
        SellerStatus = status;
    }
    public Guid SellerId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus SellerStatus { get; set; }
}