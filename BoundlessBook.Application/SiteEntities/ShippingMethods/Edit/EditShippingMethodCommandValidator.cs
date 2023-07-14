using FluentValidation;

namespace BoundlessBook.Application.SiteEntities.ShippingMethods.Edit;

public class EditShippingMethodCommandValidator : AbstractValidator<EditShippingMethodCommand>
{
    public EditShippingMethodCommandValidator()
    {
        RuleFor(f => f.Title)
            .NotNull().NotEmpty();
    }
}