using System.Collections.Immutable;
using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Domain.Model;

public sealed record GrowHub(
    Id<GrowHub> Id,
    ImmutableArray<SensorReading> SensorReadings,
    ImmutableArray<Setting> Settings,
    Id<Plant> PlantId,
    Id<User> UserId) : IEquatable<GrowHub>
{
    private GrowHub()
        : this(default, [], [], default, default) { } // Used by EF Core

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(GrowHub? other) =>
        other is not null && Id == other.Id;
}