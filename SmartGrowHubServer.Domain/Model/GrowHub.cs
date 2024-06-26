using System.Collections.Immutable;

namespace SmartGrowHubServer.Domain.Model;

public readonly record struct GrowHubId(Ulid Value)
{
    public static GrowHubId Empty { get; }

    public static GrowHubId Create() => new(Ulid.NewUlid());
}

public sealed record GrowHub(
    GrowHubId Id,
    ImmutableArray<SensorReading> SensorReadings,
    ImmutableArray<Setting> Settings,
    PlantId PlantId,
    UserId UserId) : IEquatable<GrowHub>
{
    private GrowHub() : this(
        GrowHubId.Empty,
        [], [],
        PlantId.Empty,
        UserId.Empty) { }   // Used by EF Core

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(GrowHub? other) =>
        other is not null && Id == other.Id;
}