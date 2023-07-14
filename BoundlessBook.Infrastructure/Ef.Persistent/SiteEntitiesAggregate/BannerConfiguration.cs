using BoundlessBook.Domain.SiteEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoundlessBook.Infrastructure.Ef.Persistent.SiteEntitiesAggregate;

public class BannerConfiguration : IEntityTypeConfiguration<Banner>
{
    public void Configure(EntityTypeBuilder<Banner> builder)
    {
        builder.Property(b => b.ImageName)
            .HasMaxLength(120).IsRequired();

        builder.Property(b => b.Link)
            .HasMaxLength(500).IsRequired();
    }
}