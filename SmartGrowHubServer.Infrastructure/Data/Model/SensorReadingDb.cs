using SmartGrowHubServer.Domain.Model;

namespace SmartGrowHubServer.Infrastructure.Data.Model;

public sealed record SensorReadingDb(
    Ulid Id,
    SensorType Type,
    string Value,
    string Unit,
    DateOnly CreatedAt,
    GrowHubDb Hub)
{
    private SensorReadingDb() : this(
        default!, default,
        default!, default!,
        default, default!)
    { }    // Used by EF Core
}
