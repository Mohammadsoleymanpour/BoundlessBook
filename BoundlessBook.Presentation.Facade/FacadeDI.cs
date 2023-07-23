using BoundlessBook.Presentation.Facade.Categories;
using BoundlessBook.Presentation.Facade.Comments;
using BoundlessBook.Presentation.Facade.Orders;
using BoundlessBook.Presentation.Facade.Products;
using BoundlessBook.Presentation.Facade.Roles;
using Microsoft.Extensions.DependencyInjection;

namespace BoundlessBook.Presentation.Facade;

public static class FacadeDI
{
    public static void Init(this IServiceCollection services)
    {
        services.AddTransient<ICategoryFacade, CategoryFacade>();
        services.AddTransient<ICommentFacade, CommentFacade>();
        services.AddTransient<IOrderFacade, OrderFacade>();
        services.AddTransient<IProductFacade, ProductFacade>();
        services.AddTransient<IRoleFacade, RoleFacade>();
    }
}