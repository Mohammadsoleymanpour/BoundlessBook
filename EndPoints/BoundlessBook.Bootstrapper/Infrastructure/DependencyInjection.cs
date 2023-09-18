using BoundlessBook.Bootstrapper.Infrastructure.JwtUtils;

namespace BoundlessBook.Bootstrapper.Infrastructure;

public static class DependencyInjection
{
    public static void RegisterDpendency(IServiceCollection services)
    {
        services.AddTransient<CustomJwtValidate>();
        services.AddAutoMapper(typeof(MapperProfile).Assembly);
    }
}