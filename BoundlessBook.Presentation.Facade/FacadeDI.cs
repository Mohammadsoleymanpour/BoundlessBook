using BoundlessBook.Presentation.Facade.Categories;
using BoundlessBook.Presentation.Facade.Comments;
using BoundlessBook.Presentation.Facade.Orders;
using BoundlessBook.Presentation.Facade.Products;
using BoundlessBook.Presentation.Facade.Roles;
using BoundlessBook.Presentation.Facade.Sellers;
using BoundlessBook.Presentation.Facade.SiteEntities.Banners;
using BoundlessBook.Presentation.Facade.SiteEntities.Sliders;
using BoundlessBook.Presentation.Facade.Users;
using BoundlessBook.Presentation.Facade.Users.UserAddress;
using Microsoft.Extensions.DependencyInjection;

namespace BoundlessBook.Presentation.Facade;

public static class FacadeDI
{
    public static void Init( IServiceCollection services)
    {
        services.AddTransient<ICategoryFacade, CategoryFacade>();
        services.AddTransient<ICommentFacade, CommentFacade>();
        services.AddTransient<IOrderFacade, OrderFacade>();
        services.AddTransient<IProductFacade, ProductFacade>();
        services.AddTransient<IRoleFacade, RoleFacade>();
        services.AddTransient<ISellerFacade, SellerFacade>();
        services.AddTransient<IBannerFacade, BannerFacade>();
        services.AddTransient<ISliderFacade, SliderFacade>();
        services.AddTransient<IUserFacade, UserFacade>();
        services.AddTransient<IUserAddressFacade, UserAddressFacade>();
    }
}