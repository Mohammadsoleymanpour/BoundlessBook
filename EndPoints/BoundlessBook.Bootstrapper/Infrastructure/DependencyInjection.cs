namespace BoundlessBook.Bootstrapper.Infrastructure;

public static class DependencyInjection
{
    public static void RegisterDpendency(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperProfile).Assembly);
    }
}