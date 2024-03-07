using ArquitecturaLimpiaNet8.Infraestructure.Common;
using ArquitecturaLimpiaNet8.Infraestructure.Interfaces;
using ArquitecturaLimpiaNet8.Infraestructure.Persistence;
using ArquitecturaLimpiaNet8.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArquitecturaLimpiaNet8.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection")!;
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseNpgsql(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddSingleton(TimeProvider.System);

        services.AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IOrderProductRepository, OrderProductRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
