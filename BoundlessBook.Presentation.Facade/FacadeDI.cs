using BoundlessBook.Presentation.Facade.Categories;
using BoundlessBook.Presentation.Facade.Comments;
using BoundlessBook.Presentation.Facade.Orders;
using Microsoft.Extensions.DependencyInjection;

namespace BoundlessBook.Presentation.Facade;

public static class FacadeDI
{
    public static void Init(this IServiceCollection services)
    {
        services.AddTransient<ICategoryFacade, CategoryFacade>();
        services.AddTransient<ICommentFacade, CommentFacade>();
        services.AddTransient<IOrderFacade, OrderFacade>();
    }
}