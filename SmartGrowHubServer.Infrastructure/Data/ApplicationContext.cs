using Microsoft.EntityFrameworkCore;
using SmartGrowHubServer.ApplicationL.Interfaces;
using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Model;
using SmartGrowHubServer.Infrastructure.Data.Converters;
using SmartGrowHubServer.Infrastructure.Extensions;

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
        configurationBuilder.Properties<Ulid>()
            .HaveConversion<UlidToByteArrayConverter>();

        configurationBuilder.Properties<EmailAddress>()
            .HaveConversion<EmailAddressToStringConverter>();

        configurationBuilder.Properties<NonEmptyString>()
            .HaveConversion<NonEmptyStringConverter>();

        configurationBuilder.Properties<CreatedAt>()
            .HaveConversion<CreatedAtToDateConverter>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyGlobalConversion<UlidToByteArrayConverter, Ulid, byte[]>();

        modelBuilder.Entity<User>().HasKey(user => user.Id);
        modelBuilder.Entity<User>().Property(user => user.Id)
            .HasConversion(id => id.Value, value => new UserId(value));

        modelBuilder.Entity<GrowHub>().HasKey(hub => hub.Id);
        modelBuilder.Entity<GrowHub>().Property(hub => hub.Id)
            .HasConversion(id => id.Value, value => new GrowHubId(value));

        modelBuilder.Entity<Plant>().HasKey(plant => plant.Id);
        modelBuilder.Entity<Plant>().Property(plant => plant.Id)
            .HasConversion(id => id.Value, value => new PlantId(value));

        modelBuilder.Entity<Setting>().HasKey(setting => setting.Id);
        modelBuilder.Entity<Setting>().Property(setting => setting.Id)
            .HasConversion(id => id.Value, value => new SettingId(value));

        modelBuilder.Entity<SensorReading>().HasKey(reading => reading.Id);
        modelBuilder.Entity<SensorReading>().Property(reading => reading.Id)
            .HasConversion(id => id.Value, value => new SensorReadingId(value));

        modelBuilder.Entity<Component>().HasKey(component => component.Id);
        modelBuilder.Entity<Component>().Property(component => component.Id)
            .HasConversion(id => id.Value, value => new ComponentId(value));
    }
}