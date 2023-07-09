using BoundlessBook.Common.Common.Application.Validation;
using BoundlessBook.Common.Common.Application.Validation.FluentValidations;
using FluentValidation;
using System.Drawing;

namespace BoundlessBook.Application.Orders.CheckOut;

public class CheckoutOrderCommandValidator:AbstractValidator<CheckOutOrderCommand>
{
    public CheckoutOrderCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام"));

        RuleFor(c => c.City)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("شهر"));

        RuleFor(c => c.Family)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required(" نام خانوادگی"));

        RuleFor(c => c.NationalCode)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("کد ملی"))
            .MinimumLength(10).MaximumLength(10).WithMessage("تعداد ارقام کد ملی اشتباه است").ValidNationalId("کدملی نامعتبر است");

        RuleFor(c => c.PostalAddress)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("آدرس پستی"));

        RuleFor(c => c.PostalCode)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("کذ پستی"));

        RuleFor(c => c.Shire)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("استان"));

        RuleFor(c => c.OrderId)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("آیدی سفارش"));

        RuleFor(c => c.PhoneNumber)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("شماره تلفن")).MaximumLength(11).MaximumLength(11)
            .WithMessage("تعداد ارقام شماره تلفن اشتباه است");
    }
}