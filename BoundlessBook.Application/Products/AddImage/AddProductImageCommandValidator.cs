using BoundlessBook.Common.Common.Application.Validation;
using FluentValidation;

namespace BoundlessBook.Application.Products.AddImage;

public class AddProductImageCommandValidator:AbstractValidator<AddProductImageCommand>
{
    public AddProductImageCommandValidator()
    {
        RuleFor(c => c.ImageFile)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("تصویر"));
        RuleFor(c => c.Sequence)
            .GreaterThanOrEqualTo(0);
    }
}