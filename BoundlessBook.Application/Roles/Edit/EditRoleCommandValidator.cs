using BoundlessBook.Common.Common.Application.Validation;
using FluentValidation;

namespace BoundlessBook.Application.Roles.Edit;

public class EditRoleCommandValidator:AbstractValidator<EditRoleCommand>
{
    public EditRoleCommandValidator()
    {
        RuleFor(c => c.Title)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
    }
}