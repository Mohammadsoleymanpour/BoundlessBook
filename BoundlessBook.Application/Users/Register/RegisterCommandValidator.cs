using BoundlessBook.Common.Common.Application.Validation;
using FluentValidation;

namespace BoundlessBook.Application.Users.Register;

public class RegisterCommandValidator:AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(c => c.Password).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("رمز عبور"));

        RuleFor(c => c.PhoneNumber).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("تلفن همراه"));
    }
}