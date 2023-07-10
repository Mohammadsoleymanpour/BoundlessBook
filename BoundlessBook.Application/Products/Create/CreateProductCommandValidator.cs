using BoundlessBook.Common.Common.Application.Validation;
using BoundlessBook.Common.Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BoundlessBook.Application.Products.Create;

public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
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