using BoundlessBook.Domain.CategoryAggregate;
using BoundlessBook.Domain.CommentAggregate;
using BoundlessBook.Domain.OrderAggregate;
using BoundlessBook.Domain.ProductAggregate;
using BoundlessBook.Domain.RoleAggregate;
using BoundlessBook.Domain.SellerAggregate;
using BoundlessBook.Domain.SiteEntities;
using BoundlessBook.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Infrastructure.Ef.Persistent;

public class BoundlessBookContext : DbContext
{
    public BoundlessBookContext(DbContextOptions<BoundlessBookContext> option) : base(option)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BoundlessBookContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}