using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.CommentAggregate;

namespace BoundlessBook.Application.Comments.ChangeStatus;

public class ChangeCommentStatusCommandHandler:IBaseCommandHandler<ChangeCommentStatusCommand>
{
    private readonly ICommentRepository _commentRepository;

    public ChangeCommentStatusCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    public async Task<OperationResult> Handle(ChangeCommentStatusCommand request, CancellationToken cancellationToken)
    {
        var comment =await _commentRepository.GetTracking(request.CommentId);
        if (comment == null)
        {
            return OperationResult.NotFound();
        }

        comment.ChangeStatus(request.Status);
       await _commentRepository.Save();
       return OperationResult.Success();
    }
}