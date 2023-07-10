using BoundlessBook.Common.Common.Application.Validation;
using BoundlessBook.Common.Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BoundlessBook.Application.Sellers.Create;

public class CreateSellerCommandValidator:AbstractValidator<CreateSellerCommand>
{
    public CreateSellerCommandValidator()
    {
        RuleFor(c => c.ShopName).NotEmpty()
            .WithMessage(ValidationMessages.required("نام فروشگاه"));

        RuleFor(c => c.NationalCode).NotEmpty()
            .WithMessage(ValidationMessages.required("کد ملی")).ValidNationalId();
    }
}