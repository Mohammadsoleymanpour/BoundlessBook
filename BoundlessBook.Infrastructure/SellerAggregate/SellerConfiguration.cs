using BoundlessBook.Domain.SellerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoundlessBook.Infrastructure.SellerAggregate;

public class SellerConfiguration:IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.ToTable("Sellers", "seller");
        builder.HasIndex(b => b.NationalCode).IsUnique();

        builder.Property(b => b.NationalCode)
            .IsRequired();

        builder.Property(b => b.ShopName)
            .IsRequired();

        builder.OwnsMany(b => b.SellerInventories, option =>
        {
            option.ToTable("Inventories", "seller");
            option.HasKey(b => b.Id);
            option.HasIndex(b => b.ProductId);
            option.HasIndex(b => b.SellerId);

        });
    }
}