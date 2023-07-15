using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Comments.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Comments.GetById;

public class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery,CommentDto>
{
    private readonly BoundlessBookContext _context;

    public GetCommentByIdQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<CommentDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var comment =  await _context.Comments.FirstOrDefaultAsync(c => c.Id == request.CommentId,cancellationToken);
        if (comment == null)
        {
            return null;
        }
        return comment.Map();
    }
}