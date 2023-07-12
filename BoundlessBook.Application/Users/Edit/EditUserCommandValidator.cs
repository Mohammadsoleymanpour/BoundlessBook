using BoundlessBook.Common.Common.Application.Validation;
using BoundlessBook.Common.Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace BoundlessBook.Application.Users.Edit;

public class EditUserCommandValidator:AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(c => c.Name).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("نام"));

        RuleFor(c => c.Family).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("نام خانوادگی"));

        RuleFor(c => c.Email).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("ایمیل")).EmailAddress();

        RuleFor(c => c.PhoneNumber).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("شماره تلفن همراه")).MaximumLength(11).MinimumLength(11).ValidPhoneNumber();

        RuleFor(c => c.Password).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("رمز  عبور"))
            .Length(4).WithMessage("کلمه عبور باید بیشتر از 4 کاراکتر باشد");

        RuleFor(c => c.AvatarFile).JustImageFile();
    }
}