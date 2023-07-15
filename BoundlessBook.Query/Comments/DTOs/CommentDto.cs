using BoundlessBook.Common.Common.Query;
using BoundlessBook.Common.Common.Query.Filter;
using BoundlessBook.Domain.CommentAggregate.Enums;

namespace BoundlessBook.Query.Comments.DTOs;

public class CommentDto:BaseDto
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public string FullNameUser { get; set; }
    public string ProductTitle { get; set; }
    public string Text { get; set; }
    public CommentStatus CommentStatus { get; set; }
}

public class CommentFilterParams : BaseFilterParam
{
    public Guid? UserId { get; set; }
    public Guid? ProductId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public CommentStatus? CommentStatus { get; set; }
}

public class CommentFilterResult:BaseFilter<CommentDto,CommentFilterParams>
{

}