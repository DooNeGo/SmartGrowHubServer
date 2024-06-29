using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Exceptions;
using System.Collections.Immutable;

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

    public static Try<GrowHub> Create(ImmutableArray<SensorReading> readings,
        ImmutableArray<Setting> settings, Id<Plant> plantId, Id<User> userId) => () =>
            new GrowHub(Common.Id.Create<GrowHub>(), readings, settings, plantId, userId);

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(GrowHub? other) => other is not null && Id == other.Id;

    public Try<GrowHub> AddReading(SensorReading reading) => () =>
        !SensorReadings.Contains(reading)
            ? this with { SensorReadings = SensorReadings.Add(reading) }
            : new Result<GrowHub>(new SensorReadingAlreadyExistsException());
}