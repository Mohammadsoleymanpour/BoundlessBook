using FluentValidation;

namespace BoundlessBook.Application.Users.ChargeWallet;

public class ChargeUserWalletCommandValidator:AbstractValidator<ChargeUserWalletCommand>
{
    public ChargeUserWalletCommandValidator()
    {
        RuleFor(c => c.Description).MaximumLength(500);
        RuleFor(c => c.Price).GreaterThanOrEqualTo(1000);   
    }
}