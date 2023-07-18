using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Comments.DTOs;

namespace BoundlessBook.Query.Comments.GetByFilter;

public class GetCommentByFilterQuery : QueryFilter<CommentFilterResult,CommentFilterParams>, IQuery<CommentFilterResult>
{
    public GetCommentByFilterQuery(CommentFilterParams param) : base(param)
    {
    }
}