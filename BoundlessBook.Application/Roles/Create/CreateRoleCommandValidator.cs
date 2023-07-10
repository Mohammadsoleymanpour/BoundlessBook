using BoundlessBook.Common.Common.Application.Validation;
using FluentValidation;

namespace BoundlessBook.Application.Roles.Create;

public class CreateRoleCommandValidator:AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(c => c.Title)
            .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
    }
}