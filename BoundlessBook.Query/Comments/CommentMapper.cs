using BoundlessBook.Domain.CommentAggregate;
using BoundlessBook.Query.Comments.DTOs;

namespace BoundlessBook.Query.Comments;

public static class CommentMapper
{
    public static CommentDto Map(this Comment dto)
    {
        return new CommentDto()
        {
            IsDelete = dto.IsDelete,
            CreationDate = dto.CreationDate,
            CommentStatus = dto.CommentStatus,
            Id = dto.Id,
            ProductId = dto.ProductId,
            Text = dto.Text,
            UserId = dto.UserId,
        };
    }
}