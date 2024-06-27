using Microsoft.EntityFrameworkCore;
using SmartGrowHubServer.Domain.Model;

namespace SmartGrowHubServer.ApplicationL.Interfaces;

public interface IApplicationContext
{
    DbSet<User> Users { get; }
    DbSet<GrowHub> GrowHubs { get; }
    DbSet<Plant> Plants { get; }
    DbSet<Setting> Settings { get; }
    DbSet<SensorReading> SensorReading { get; }
    DbSet<Component> Components { get; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}