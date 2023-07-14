using BoundlessBook.Domain.SiteEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoundlessBook.Infrastructure.Ef.Persistent.SiteEntitiesAggregate;

public class SliderConfiguration : IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {

        builder.Property(b => b.ImageName)
            .HasMaxLength(120).IsRequired();

        builder.Property(b => b.Title)
            .HasMaxLength(120);

        builder.Property(b => b.Link)
            .HasMaxLength(500);
    }
}