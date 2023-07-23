using BoundlessBook.Application.Comments.ChangeStatus;
using BoundlessBook.Application.Comments.Create;
using BoundlessBook.Application.Comments.Edit;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Comments.DTOs;

namespace BoundlessBook.Presentation.Facade.Comments;

public interface ICommentFacade
{
    Task<OperationResult> Create(CreateCommentCommand  command);
    Task<OperationResult> Edit(EditCommentCommand command);
    Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand  command);

    Task<CommentFilterResult> GetByFilter(CommentFilterParams  filterParams);
    Task<CommentDto> GetById(Guid id);

}