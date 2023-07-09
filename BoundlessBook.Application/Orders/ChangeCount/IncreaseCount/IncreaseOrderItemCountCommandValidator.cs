using BoundlessBook.Common.Common.Application.Validation;
using FluentValidation;

namespace BoundlessBook.Application.Orders.ChangeCount.IncreaseCount;

public class IncreaseOrderItemCountCommandValidator : AbstractValidator<IncreaseOrderItemCountCommand>
{
    public IncreaseOrderItemCountCommandValidator()
    {
        RuleFor(c => c.ItemId).NotNull().NotEmpty().WithMessage(ValidationMessages.required("آیدی ایتم"));
        RuleFor(c => c.UserId).NotNull().NotEmpty().WithMessage(ValidationMessages.required("آیدی کاربر"));

        RuleFor(c => c.Count).GreaterThanOrEqualTo(1).WithMessage(ValidationMessages.maxLength("تعداد", 0));
    }
}