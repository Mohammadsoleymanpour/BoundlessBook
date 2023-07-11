using System.ComponentModel.Design;
using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.Exceptions;
using BoundlessBook.Domain.SellerAggregate.Enums;
using BoundlessBook.Domain.SellerAggregate.Services;

namespace BoundlessBook.Domain.SellerAggregate;

public class Seller : AggregateRoot
{
    public Seller(Guid userId, string shopName, string nationalCode, ISellerDomainService sellerDomainService)
    {
        Guard(shopName, nationalCode);
        UserId = userId;
        ShopName = shopName;
        NationalCode = nationalCode;
        SellerInventories = new List<SellerInventory>();
        if (!sellerDomainService.CheckSellerInfo(this))
        {
            throw new InvalidDomainException("اطلاعات نا معتبر است");
        }
    }

    public Seller()
    {

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

    public void Edit(string name, string nationalCode,SellerStatus status, ISellerDomainService sellerDomainService)
    {
        Guard(name, nationalCode);
        ShopName = name;
        if (nationalCode != NationalCode)
        {
            if (sellerDomainService.NationalCodeIsExist(nationalCode))
            {
                throw new InvalidDomainException("کد ملی تکراری است ");
            }
        }
        NationalCode = nationalCode;
        ChangeStatus(status);
        LastUpdate = DateTime.Now;
    }

    public void Guard(string shopName, string nationalCode)
    {
        NullOrEmptyDomainException.CheckString(shopName, nameof(shopName));
        NullOrEmptyDomainException.CheckString(nationalCode, nameof(nationalCode));
        if (!IranianNationalCodeChecker.IsValid(nationalCode))
        {
            throw new InvalidDomainException("کد ملی وارد شده معتبر نیست");
        }
    }

    public void AddInventory(SellerInventory inventory)
    {
        if (SellerInventories.Any(c => c.ProductId == inventory.ProductId))
        {
            throw new InvalidDomainException("این محصول قبلا ثبت شده است");
        }

        SellerInventories.Add(inventory);
    }

    public void EditInventory(Guid inventoryId,int count,float price,int? discountPercent)
    {
        var currentInventory = SellerInventories.FirstOrDefault(c => c.Id == inventoryId);
        if (currentInventory == null)
        {
            throw new NullOrEmptyDomainException("انباری یافت نشد");
        }

        //TODO CHECK WORK
        currentInventory.Edit(count,price,discountPercent);

    }

    public void DeleteInventory(Guid inventoryId)
    {
        var currentInventory = SellerInventories.FirstOrDefault(c => c.Id == inventoryId);
        if (currentInventory == null)
        {
            throw new NullOrEmptyDomainException("انباری یافت نشد");
        }

        SellerInventories.Remove(currentInventory);
    }

}