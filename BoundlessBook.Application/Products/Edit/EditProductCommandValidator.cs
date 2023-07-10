using BoundlessBook.Common.Common.Application.Validation;
using BoundlessBook.Common.Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BoundlessBook.Application.Products.Edit;

public class EditProductCommandValidator:AbstractValidator<EditProductCommand>
{
    public EditProductCommandValidator()
    {
        RuleFor(c => c.Title)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(c => c.Description)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

        RuleFor(c => c.ImageFile)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عکس")).JustImageFile();

        RuleFor(c => c.Slug)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));

    }
}