using BoundlessBook.Common.Common.Application.Validation;
using FluentValidation;

namespace BoundlessBook.Application.Sellers.AddInventory;

public class AddSellerInventoryCommandValidator:AbstractValidator<AddSellerInventoryCommand>
{
    public AddSellerInventoryCommandValidator()
    {
        RuleFor(c => c.Count).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("تعداد"))
            .GreaterThanOrEqualTo(1);

        RuleFor(c => c.Price).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("قیمت"))
            .GreaterThanOrEqualTo(1);
    }

}