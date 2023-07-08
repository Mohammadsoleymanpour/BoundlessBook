using BoundlessBook.Common.Common.Application.Validation;
using FluentValidation;

namespace BoundlessBook.Application.Comments.ChangeStatus;

public class ChangeCommentStatusCommandValidator:AbstractValidator<ChangeCommentStatusCommand>
{
    public ChangeCommentStatusCommandValidator()
    {
        RuleFor(c=>c.CommentId).NotEmpty().NotNull().WithMessage(ValidationMessages.required("آیدی کامنت"));
        RuleFor(c => c.Status).NotNull().NotEmpty().WithMessage(ValidationMessages.required("وضعیت جدید"));
    }
}