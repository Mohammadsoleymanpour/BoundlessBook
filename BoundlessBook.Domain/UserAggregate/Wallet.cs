using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.Exceptions;
using BoundlessBook.Domain.UserAggregate.Enums;

namespace BoundlessBook.Domain.UserAggregate;

public class Wallet : BaseEntity
{
    public Wallet( float price, string? description, bool isFinally, WalletType type)
    {
        if (price<500)
        {
            throw new InvalidDomainException("مبلغ وارد شده از حد مجاز کمتر است");
        }
        Price = price;
        Description = description;
        IsFinally = isFinally;
        Type = type;
        if (isFinally)
        {
            FinallyDate = DateTime.Now;
        }
    }


    public Guid UserId { get; set; }
    public float Price { get; set; }
    public string? Description { get; set; }
    public bool IsFinally { get; set; }=false;
    public DateTime FinallyDate { get; set; }
    public WalletType Type { get; set; }


    public void Finally(string refCode)
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
        Description += $"کد پیگیری :{refCode}";
    }

    public void Finally()
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
    }
}