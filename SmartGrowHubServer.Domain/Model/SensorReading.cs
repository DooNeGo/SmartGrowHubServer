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
        default, default,
        default, default,
        default, default)
    { }    // Used by EF Core
}