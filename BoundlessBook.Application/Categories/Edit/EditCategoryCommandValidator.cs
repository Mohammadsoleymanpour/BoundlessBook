using BoundlessBook.Common.Common.Application.Validation;
using FluentValidation;

namespace BoundlessBook.Application.Categories.Edit;

public class EditCategoryCommandValidator:AbstractValidator<EditCategoryCommand>
{
    public EditCategoryCommandValidator()
    {
        RuleFor(c => c.Title).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(c => c.Slug).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("عنوان"));
    }
}