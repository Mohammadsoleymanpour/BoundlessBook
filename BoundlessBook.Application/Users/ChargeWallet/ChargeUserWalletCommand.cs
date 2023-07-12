using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.UserAggregate.Enums;

namespace BoundlessBook.Application.Users.ChargeWallet;

public class ChargeUserWalletCommand:IBaseCommand
{
    public ChargeUserWalletCommand(Guid userId, float price, string? description, bool isFinally, WalletType type)
    {
        UserId = userId;
        Price = price;
        Description = description;
        IsFinally = isFinally;
        Type = type;
    }
    public Guid UserId { get; set; }
    public float Price { get; set; }
    public string? Description { get; set; }
    public bool IsFinally { get; set; } = false;

    public WalletType Type { get; set; }
}