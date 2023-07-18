using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Comments.DTOs;

namespace BoundlessBook.Query.Comments.GetById;

public record GetCommentByIdQuery(Guid CommentId):IQuery<CommentDto>;