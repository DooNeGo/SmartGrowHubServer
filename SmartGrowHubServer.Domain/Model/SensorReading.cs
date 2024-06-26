using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Domain.Model;

public readonly record struct SensorReadingId(Ulid Value)
{
    public static SensorReadingId Empty { get; }

    public static SensorReadingId Create() => new(Ulid.NewUlid());
}

public sealed record SensorReading(
    SensorReadingId Id,
    SensorType Type,
    NonEmptyString Value,
    NonEmptyString Unit,
    CreatedAt CreatedAt,
    GrowHubId GrowHubItemId)
{
    private SensorReading() : this(
        SensorReadingId.Empty,
        default,
        NonEmptyString.Empty,
        NonEmptyString.Empty,
        CreatedAt.Empty,
        GrowHubId.Empty) { }    // Used by EF Core
}