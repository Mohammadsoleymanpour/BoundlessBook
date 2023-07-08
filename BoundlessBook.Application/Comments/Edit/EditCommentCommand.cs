using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Comments.Edit;

public record EditCommentCommand(Guid CommentId,Guid UserId,string Text) : IBaseCommand;

