using CleanArchitectureDemo.Application;
using CleanArchitectureDemo.Infrastructure;
using CleanArchitectureDemo.Persistence;

namespace CleanArchitectureDemo.WebAPI.Configurations;

public static class GeneralConfiguration
{
    public static void AddGeneralConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddApplicationLayer();
        services.AddPersistenceLayer(configuration);
        services.AddInfrastructureLayer(configuration);
    }
}
