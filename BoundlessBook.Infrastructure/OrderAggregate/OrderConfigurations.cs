using BoundlessBook.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoundlessBook.Infrastructure.OrderAggregate;

public class OrderConfigurations:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders", "order");

        builder.OwnsOne(c => c.ShippingMethod, option =>
        {
            option.Property(c => c.Title)
                .HasMaxLength(50);
        });

        builder.OwnsMany(c => c.OrderItems, option =>
        {
            option.ToTable("OrderItems", "order");
        });

        builder.OwnsOne(c => c.Address, option =>
        {
            option.ToTable("Addresses", "order");
            option.Property(c => c.City)
                .HasMaxLength(50);
        });

    }
}