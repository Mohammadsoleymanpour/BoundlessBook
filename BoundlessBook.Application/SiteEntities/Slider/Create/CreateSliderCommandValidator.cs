using BoundlessBook.Common.Common.Application.Validation;
using BoundlessBook.Common.Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BoundlessBook.Application.SiteEntities.Slider.Create;

public class CreateSliderCommandValidator:AbstractValidator<CreateSliderCommand>
{
    public CreateSliderCommandValidator()
    {
        RuleFor(c => c.ImageFile).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("عکس"))
            .JustImageFile();

        RuleFor(c => c.Title).NotNull().NotEmpty();
        

    }
}