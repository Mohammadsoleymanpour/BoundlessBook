using BoundlessBook.Domain.RoleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoundlessBook.Infrastructure.RoleAggregate;

public class RoleConfiguration:IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles", "role");
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(60);

        builder.OwnsMany(b => b.RolePermissions, option =>
        {
            option.ToTable("Permissions", "role");
        });
    }
}