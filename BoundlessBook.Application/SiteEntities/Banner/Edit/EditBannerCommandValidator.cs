using BoundlessBook.Common.Common.Application.Validation;
using BoundlessBook.Common.Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BoundlessBook.Application.SiteEntities.Banner.Edit;

public class EditBannerCommandValidator:AbstractValidator<EditBannerCommand>
{
    public EditBannerCommandValidator()
    {
        RuleFor(c => c.ImageFile).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("عکس"))
            .JustImageFile();

    }
}