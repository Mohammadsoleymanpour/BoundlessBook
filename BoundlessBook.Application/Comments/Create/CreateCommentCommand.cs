using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Comments.Create;

public record CreateCommentCommand(Guid UserId, Guid ProductId, string Text) : IBaseCommand;
