using Microsoft.EntityFrameworkCore;
using SmartGrowHubServer.ApplicationL.Interfaces;
using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Model;
using SmartGrowHubServer.Infrastructure.Data.Converters;
using SmartGrowHubServer.Infrastructure.Data.Extensions;

namespace SmartGrowHubServer.Infrastructure.Data;

internal sealed class ApplicationContext : DbContext, IApplicationContext
{
    private const string ConnectionString =
        @"Server=(localdb)\mssqllocaldb;Database=SmartGrowHubDb;Trusted_Connection=True;";

    public DbSet<User> Users => Set<User>();

    public DbSet<GrowHub> GrowHubs => Set<GrowHub>();

    public DbSet<Plant> Plants => Set<Plant>();

    public DbSet<Setting> Settings => Set<Setting>();

    public DbSet<SensorReading> SensorReading => Set<SensorReading>();

    public DbSet<Component> Components => Set<Component>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder
            .AddConversion(new ValueObjectConverter<EmailAddress, string>())
            .AddConversion(new ValueObjectConverter<NonEmptyString, string>())
            .AddConversion(new ValueObjectConverter<LatinString, string>())
            .AddConversion(new ValueObjectConverter<BoundedString, string>())
            .AddConversion(new ValueObjectConverter<NonNegativeInteger, int>())
            .AddConversion(new ValueObjectConverter<UserName, string>())
            .AddConversion(new ValueObjectConverter<Password, string>())
            .AddConversion(new ValueObjectConverter<CreatedAt, DateOnly>())
            .AddIdConversion<User>()
            .AddIdConversion<GrowHub>()
            .AddIdConversion<Plant>()
            .AddIdConversion<Setting>()
            .AddIdConversion<SensorReading>()
            .AddIdConversion<Component>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasKey(user => user.Id);
        modelBuilder.Entity<GrowHub>().HasKey(hub => hub.Id);
        modelBuilder.Entity<Plant>().HasKey(plant => plant.Id);
        modelBuilder.Entity<Setting>().HasKey(setting => setting.Id);
        modelBuilder.Entity<SensorReading>().HasKey(reading => reading.Id);
        modelBuilder.Entity<Component>().HasKey(component => component.Id);
    }
}