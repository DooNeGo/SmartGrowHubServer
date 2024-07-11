using System.Collections.Immutable;

namespace SmartGrowHubServer.Infrastructure.Data.Model;

public sealed record GrowHubDb(
    Ulid Id,
    ImmutableArray<SensorReadingDb> SensorReadings,
    ImmutableArray<SettingDb> Settings,
    PlantDb? Plant,
    UserDb User)
{
    private GrowHubDb() : this(
        default!, [], [],
        default, default!)
    { }   // Used by EF Core
}
