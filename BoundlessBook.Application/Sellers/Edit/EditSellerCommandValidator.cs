using BoundlessBook.Common.Common.Application.Validation;
using BoundlessBook.Common.Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BoundlessBook.Application.Sellers.Edit;

public class EditSellerCommandValidator:AbstractValidator<EditSellerCommand>
{
    public EditSellerCommandValidator()
    {
        RuleFor(c => c.ShopName).NotEmpty()
            .WithMessage(ValidationMessages.required("نام فروشگاه"));

        RuleFor(c => c.NationalCode).NotEmpty()
            .WithMessage(ValidationMessages.required("کد ملی")).ValidNationalId();
    }
}