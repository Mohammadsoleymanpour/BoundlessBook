using BoundlessBook.Common.Common.Application.Validation;
using BoundlessBook.Common.Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BoundlessBook.Application.SiteEntities.Slider.Edit;

public class EditSliderCommandValidator:AbstractValidator<EditSliderCommand>
{
    public EditSliderCommandValidator()
    {
        RuleFor(c => c.ImageFile).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("عکس"))
            .JustImageFile();

        RuleFor(c => c.Title).NotNull().NotEmpty();
    }
}