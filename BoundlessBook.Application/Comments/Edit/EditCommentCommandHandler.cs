using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.CommentAggregate;

namespace BoundlessBook.Application.Comments.Edit;

public class EditCommentCommandHandler:IBaseCommandHandler<EditCommentCommand>
{
    private readonly ICommentRepository _commentRepository;

    public EditCommentCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    public async Task<OperationResult> Handle(EditCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetTracking(request.CommentId);
        if (comment==null || request.UserId!=comment.UserId)
        {
            return OperationResult.NotFound();
        }

        comment.Edit(text:request.Text);
        await _commentRepository.Save();
        return OperationResult.Success();
    }
}