using System.Linq.Expressions;
using BoundlessBook.Domain.CategoryAggregate;
using BoundlessBook.Domain.OrderAggregate.Repository;
using BoundlessBook.Domain.ProductAggregate.Repository;
using BoundlessBook.Domain.RoleAggregate;
using BoundlessBook.Domain.SellerAggregate;
using BoundlessBook.Domain.SiteEntities.Repositories;
using BoundlessBook.Domain.UserAggregate.Repository;
using BoundlessBook.Infrastructure.Dapper.Persistent;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Infrastructure.Ef.Persistent.CategoryAggregate;
using BoundlessBook.Infrastructure.Ef.Persistent.OrderAggregate;
using BoundlessBook.Infrastructure.Ef.Persistent.ProductAggregate;
using BoundlessBook.Infrastructure.Ef.Persistent.RoleAggregate;
using BoundlessBook.Infrastructure.Ef.Persistent.SellerAggregate;
using BoundlessBook.Infrastructure.Ef.Persistent.SiteEntitiesAggregate.Repositories;
using BoundlessBook.Infrastructure.Ef.Persistent.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BoundlessBook.Infrastructure;

public static class InfrastructureDI
{
    public static void Init(IServiceCollection services, string connectionString)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<ISellerRepository, SellerRepository>();
        services.AddTransient<IBannerRepository, BannerRepository>();
        services.AddTransient<ISliderRepository, SliderRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IShippingMethodRepository, ShippingRepository>();


        services.AddTransient(_ => new DapperContext(connectionString));
        services.AddDbContext<BoundlessBookContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
    }
}