using Microsoft.EntityFrameworkCore;
using SmartGrowHubServer.Infrastructure.Data.CompiledModels;
using SmartGrowHubServer.Infrastructure.Data.Convertors;
using SmartGrowHubServer.Infrastructure.Data.Model;

namespace SmartGrowHubServer.Infrastructure.Data;

internal sealed class ApplicationContext : DbContext
{
    private const string ConnectionString =
        @"Server=(localdb)\mssqllocaldb;Database=SmartGrowHubDb;Trusted_Connection=True;";

    public DbSet<UserDb> Users => Set<UserDb>();

    public DbSet<GrowHubDb> GrowHubs => Set<GrowHubDb>();

    public DbSet<PlantDb> Plants => Set<PlantDb>();

    public DbSet<SettingDb> Settings => Set<SettingDb>();

    public DbSet<SensorReadingDb> SensorReading => Set<SensorReadingDb>();

    public DbSet<ComponentDb> Components => Set<ComponentDb>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder
            .UseSqlServer(ConnectionString)
            .UseModel(ApplicationContextModel.Instance);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder
            .Properties<Ulid>()
            .HaveConversion<UlidConverter>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserDb>().HasKey(user => user.Id);
        modelBuilder.Entity<GrowHubDb>().HasKey(hub => hub.Id);
        modelBuilder.Entity<PlantDb>().HasKey(plant => plant.Id);
        modelBuilder.Entity<SettingDb>().HasKey(setting => setting.Id);
        modelBuilder.Entity<SensorReadingDb>().HasKey(reading => reading.Id);
        modelBuilder.Entity<ComponentDb>().HasKey(component => component.Id);
    }
}