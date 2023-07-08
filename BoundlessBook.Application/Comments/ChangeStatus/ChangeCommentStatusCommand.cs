using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.CommentAggregate.Enums;

namespace BoundlessBook.Application.Comments.ChangeStatus;

public record ChangeCommentStatusCommand(Guid CommentId, CommentStatus Status) : IBaseCommand;
