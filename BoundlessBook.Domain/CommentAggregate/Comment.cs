using BoundlessBook.Common;

namespace BoundlessBook.Domain.CommentAggregate;

public class Comment:AggregateRoot
{
    public Guid  UserId { get; set; }
    public Guid ProductId { get; set; }
    public string Text { get; set; }
    
}