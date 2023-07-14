using BoundlessBook.Domain.CategoryAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoundlessBook.Infrastructure.Ef.Persistent.CategoryAggregate;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories", "category");

        builder.HasKey(x => x.Id);
        builder.HasIndex(b => b.Slug).IsUnique();

        builder.Property(b => b.Slug)
            .IsRequired()
            .IsUnicode(false);

        builder.Property(b => b.Title)
            .IsRequired();

        builder
            .HasMany(b => b.Child)
            .WithOne()
            .HasForeignKey(b => b.ParentId);

        builder.OwnsOne(b => b.SeoData, config =>
      {
          config.Property(b => b.MetaDescription)
              .HasMaxLength(500)
              .HasColumnName("MetaDescription");

          config.Property(b => b.MetaTitle)
              .HasMaxLength(500)
              .HasColumnName("MetaTitle");

          config.Property(b => b.MetaKeyWords)
              .HasMaxLength(500)
              .HasColumnName("MetaKeyWords");

          config.Property(b => b.IndexPage)
              .HasColumnName("IndexPage");

          config.Property(b => b.Canonical)
              .HasMaxLength(500)
              .HasColumnName("Canonical");

          config.Property(b => b.Schema)
              .HasColumnName("Schema");
      });
    }
}