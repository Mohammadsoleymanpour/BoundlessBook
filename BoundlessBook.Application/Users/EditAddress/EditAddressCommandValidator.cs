using BoundlessBook.Common.Common.Application.Validation;
using BoundlessBook.Common.Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BoundlessBook.Application.Users.EditAddress;

public class EditAddressCommandValidator:AbstractValidator<EditAddressCommand>
{
    public EditAddressCommandValidator()
    {
        RuleFor(c => c.Name).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("نام"));

        RuleFor(c => c.Family).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("نام خانوادگی"));

        RuleFor(c => c.City).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("شهر"));

        RuleFor(c => c.NationalCode).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("کد ملی"))
            .ValidNationalId();

        RuleFor(c => c.PhoneNumber).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("تلقن همراه"))
            .ValidPhoneNumber();

        RuleFor(c => c.PostalAddress).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("آدرس پستی"));

        RuleFor(c => c.PostalCode).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("کد پستی"));

        RuleFor(c => c.Shire).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("استان"));
    }
}