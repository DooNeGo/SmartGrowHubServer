using Microsoft.Extensions.DependencyInjection;
using SmartGrowHubServer.ApplicationL.Interfaces;
using SmartGrowHubServer.Infrastructure.Data;

namespace SmartGrowHubServer.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services.AddMediator().AddDbContext<IApplicationContext, ApplicationContext>();
}
