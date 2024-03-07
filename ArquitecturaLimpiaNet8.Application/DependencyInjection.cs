using ArquitecturaLimpiaNet8.Application.Services;
using ArquitecturaLimpiaNet8.Infraestructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ArquitecturaLimpiaNet8.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddInfraestructureServices(configuration);

        services.AddHttpClient("ProductHttp", client =>
        {
            client.BaseAddress = new Uri(configuration["Services:ProductsApi"]!);
        });

        string redisConnection = configuration.GetConnectionString("RedisConnection")!;

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnection;
            options.InstanceName = "arquitecturalimpianet8";
        });

        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
