using Microsoft.Extensions.DependencyInjection;
using SmartGrowHubServer.Infrastructure.Data;

namespace SmartGrowHubServer.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services.AddDbContext<ApplicationContext>().AddMediator();
}