using BoundlessBook.Common.Common.Application.Validation;
using FluentValidation;

namespace BoundlessBook.Application.Categories.Create;

public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Title).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(c => c.Slug).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("Slug"));
    }
}