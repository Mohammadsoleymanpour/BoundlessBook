using BoundlessBook.Common.Common.Application.Validation;
using FluentValidation;

namespace BoundlessBook.Application.Categories.AddChild;

public class AddCategoryChildValidator:AbstractValidator<AddCategoryChildCommand>
{
    public AddCategoryChildValidator()
    {
        RuleFor(c => c.Title).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(c => c.Slug).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("عنوان"));
    }
}