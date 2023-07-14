using BoundlessBook.Domain.CommentAggregate;
using BoundlessBook.Infrastructure._Utilities;

namespace BoundlessBook.Infrastructure.Ef.Persistent.CommentAggregate;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(BoundlessBookContext context) : base(context)
    {
    }
}