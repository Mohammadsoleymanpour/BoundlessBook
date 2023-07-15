using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Comments.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Comments.GetByFilter;

public class GetCommentByFilterQueryHandler : IQueryHandler<GetCommentByFilterQuery,CommentFilterResult >
{
    private readonly BoundlessBookContext _context;

    public GetCommentByFilterQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParam;

        var result = _context.Comments.OrderByDescending(c => c.CreationDate).AsQueryable();

        if (@params.UserId!=null)
        {
            result = result.Where(c => c.UserId == @params.UserId);
        }

        if (@params.ProductId!=null)
        {
            result = result.Where(c => c.ProductId == @params.ProductId);
        }

        if (@params.CommentStatus!=null)
        {
            result = result.Where(c => c.CommentStatus == @params.CommentStatus);
        }

        if (@params.StartDate!=null)
        {
            result = result.Where(c => c.CreationDate.Date >= @params.StartDate);
        }

        if (@params.EndDate != null)
        {
            result = result.Where(c => c.CreationDate <= @params.EndDate);
        }

        var skip = (@params.PageId - 1) * @params.Take;
        var model = new CommentFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take).Select(c => c.Map())
                .ToListAsync(cancellationToken),
            FilterParams = @params
        };

        model.GeneratePaging(result,@params.Take,@params.PageId);
        return model;
    }
}