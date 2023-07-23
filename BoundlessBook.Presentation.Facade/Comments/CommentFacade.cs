using BoundlessBook.Application.Comments.ChangeStatus;
using BoundlessBook.Application.Comments.Create;
using BoundlessBook.Application.Comments.Edit;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Comments.DTOs;
using BoundlessBook.Query.Comments.GetByFilter;
using BoundlessBook.Query.Comments.GetById;
using MediatR;

namespace BoundlessBook.Presentation.Facade.Comments;

public class CommentFacade : ICommentFacade
{
    private readonly IMediator _mediator;

    public CommentFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> Create(CreateCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<CommentFilterResult> GetByFilter(CommentFilterParams filterParams)
    {
        return await _mediator.Send(new GetCommentByFilterQuery(filterParams));
    }

    public async Task<CommentDto> GetById(Guid id)
    {
        return await _mediator.Send(new GetCommentByIdQuery(id));
    }
}