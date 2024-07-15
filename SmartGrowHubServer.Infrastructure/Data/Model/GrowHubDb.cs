using System.Collections.Immutable;

namespace SmartGrowHubServer.Infrastructure.Data.Model;

public sealed record GrowHubDb(
    Ulid Id,
    ImmutableArray<SensorReadingDb> SensorReadings,
    ImmutableArray<SettingDb> Settings,
    Ulid? PlantId,
    PlantDb? Plant,
    Ulid UserId,
    UserDb User)
{
    private GrowHubDb() : this(
        default!, [], [],
        default, default!,
        default, default!)
    { }   // Used by EF Core
}
