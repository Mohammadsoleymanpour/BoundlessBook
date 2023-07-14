using BoundlessBook.Domain.CommentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoundlessBook.Infrastructure.Ef.Persistent.CommentAggregate;

public class CommentConfigurations : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {

    }
}