using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Domain.Model;

public sealed record SensorReading(
    Id<SensorReading> Id,
    SensorType Type,
    NonEmptyString Value,
    NonEmptyString Unit,
    CreatedAt CreatedAt,
    Id<GrowHub> GrowHubItemId)
{
    private SensorReading() : this(
        default,
        default,
        NonEmptyString.Empty,
        NonEmptyString.Empty,
        CreatedAt.Empty,
        default)
    { }    // Used by EF Core
}