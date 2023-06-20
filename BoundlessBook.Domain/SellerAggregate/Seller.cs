using BoundlessBook.Common;
using BoundlessBook.Common.Exceptions;
using BoundlessBook.Domain.SellerAggregate.Enums;

namespace BoundlessBook.Domain.SellerAggregate;

public class Seller:AggregateRoot
{
    public Seller(Guid userId, string shopName, string nationalCode)
    {
        Guard(shopName,nationalCode);
        UserId = userId;
        ShopName = shopName;
        NationalCode = nationalCode;
        

    }
    public Guid UserId { get; set; }

    public string ShopName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus SellerStatus { get; set; }
    public DateTime LastUpdate { get; set; }
    public List<SellerInventory> SellerInventories { get; set; }

    public void ChangeStatus(SellerStatus status)
    {
        SellerStatus = status;
        LastUpdate = DateTime.Now;
    }

    public void Edit(string name, string nationalCode)
    {
        Guard(name,nationalCode);
        ShopName = name;
        NationalCode = nationalCode;
    }

    public void Guard(string shopName,string nationalCode)
    {
        NullOrEmptyDomainException.CheckString(shopName,nameof(shopName));
        NullOrEmptyDomainException.CheckString(nationalCode,nameof(nationalCode));
        if (!IranianNationalCodeChecker.IsValid(nationalCode))
        {
            throw new InvalidDomainException("کد ملی وارد شده معتبر نیست");
        }


    }

}