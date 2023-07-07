using BoundlessBook.Common.Common.Application.Validation;
using FluentValidation;

namespace BoundlessBook.Application.Comments.Create;

public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentValidator()
    {
        RuleFor(c => c.ProductId).NotNull().NotEmpty();
        RuleFor(c => c.ProductId).NotNull().NotEmpty();
        RuleFor(c => c.Text).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("متن"))
            .MaximumLength(500).WithMessage(ValidationMessages.maxLength("متن", 500))
            .MinimumLength(5).WithMessage(ValidationMessages.minLength("متن", 5));
    }
}