using BoundlessBook.Application.Categories;
using BoundlessBook.Application.Products;
using BoundlessBook.Application.Sellers;
using BoundlessBook.Application.Users;
using BoundlessBook.Common.Common.Application.Utilities;
using BoundlessBook.Domain.CategoryAggregate.Service;
using BoundlessBook.Domain.ProductAggregate.Services;
using BoundlessBook.Domain.SellerAggregate.Services;
using BoundlessBook.Domain.UserAggregate.Services;
using BoundlessBook.Infrastructure;
using BoundlessBook.Query.Categories.GetById;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BoundlessBook.Config
{
    public static class BoundlessBookConfig
    {

        public static void RegisterDependency(IServiceCollection service, string connectionString)
        {
            InfrastructureDI.Init(service,connectionString);

            service.AddMediatR(typeof(Directories).Assembly);

            service.AddMediatR(typeof(GetCategoryByIdQuery).Assembly);

            service.AddTransient<IProductDomainService, ProductDomainService>();
            service.AddTransient<ICategoryDomainService, CategoryDomainService>();
            service.AddTransient<IUserDomainService, UserDomainService>();
            service.AddTransient<ISellerDomainService, SellerDomainService>();
        }
    }
}