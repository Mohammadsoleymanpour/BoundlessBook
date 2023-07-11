using BoundlessBook.Common.Common.Application.Validation;
using BoundlessBook.Common.Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BoundlessBook.Application.SiteEntities.Banner.Create;

public class CreateBannerCommandValidator:AbstractValidator<CreateBannerCommand>
{
    public CreateBannerCommandValidator()
    {
        RuleFor(c => c.ImageFile).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("عکس"))
            .JustImageFile();


    }
}