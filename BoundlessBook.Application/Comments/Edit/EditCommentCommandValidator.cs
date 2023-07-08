using BoundlessBook.Common.Common.Application.Validation;
using FluentValidation;

namespace BoundlessBook.Application.Comments.Edit;

public class EditCommentCommandValidator:AbstractValidator<EditCommentCommand>
{
    public EditCommentCommandValidator()
    {
        RuleFor(c => c.CommentId).NotNull().NotEmpty();
        RuleFor(c => c.UserId).NotNull().NotEmpty();

        RuleFor(c => c.Text).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("متن"))
            .MaximumLength(500).WithMessage(ValidationMessages.maxLength("متن", 500))
            .MinimumLength(5).WithMessage(ValidationMessages.minLength("متن", 5));
    }
}