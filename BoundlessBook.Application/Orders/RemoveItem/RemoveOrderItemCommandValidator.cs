using BoundlessBook.Common.Common.Application.Validation;
using FluentValidation;

namespace BoundlessBook.Application.Orders.RemoveItem;

public class RemoveOrderItemCommandValidator:AbstractValidator<RemoveOrderItemCommand>
{
    public RemoveOrderItemCommandValidator()
    {
        RuleFor(c => c.ItemId).NotNull().NotEmpty().WithMessage(ValidationMessages.required("آیدی ایتم"));
        RuleFor(c => c.UserId).NotNull().NotEmpty().WithMessage(ValidationMessages.required("آیدی کاربر"));

    }
}