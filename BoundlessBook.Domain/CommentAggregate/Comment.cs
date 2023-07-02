using BoundlessBook.Common;
using BoundlessBook.Common.Exceptions;
using BoundlessBook.Domain.CommentAggregate.Enums;

namespace BoundlessBook.Domain.CommentAggregate;

public class Comment:AggregateRoot
{
    public Comment()
    {
        
    }
    public Comment(Guid userId, Guid productId, string text)
    {
        NullOrEmptyDomainException.CheckString(text,nameof(text));
        UserId = userId;
        ProductId = productId;
        Text = text;
        CommentStatus = CommentStatus.Pending;
    }
    public Guid  UserId { get; set; }
    public Guid ProductId { get; set; }
    public string Text { get; set; }
    public CommentStatus CommentStatus { get; set; }
    public DateTime LastUpdate { get; set; }

    public void Edit(string text)
    {
        NullOrEmptyDomainException.CheckString(text, nameof(text));
        Text =text;
        LastUpdate=DateTime.Now;
    }

    public void ChangeStatus(CommentStatus status)
    {
        CommentStatus = status;
        LastUpdate = DateTime.Now;
    }
}