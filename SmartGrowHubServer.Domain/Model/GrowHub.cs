using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Exceptions;
using System.Collections.Immutable;

namespace SmartGrowHubServer.Domain.Model;

public readonly record struct GrowHub(
    Id<GrowHub> Id,
    ImmutableArray<SensorReading> SensorReadings,
    ImmutableArray<Setting> Settings,
    Option<Plant> Plant)
{
    private static readonly ItemAlreadyExistsException AlreadyExistsException =
        new(nameof(SensorReading), nameof(GrowHub));

    public static Identity<GrowHub> Create(ImmutableArray<Setting> settings) =>
        Id<GrowHub>(new(Common.Id.Create<GrowHub>(), [], settings, None));

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(GrowHub other) => Id == other.Id;

    public Fin<GrowHub> AddReading(SensorReading reading) =>
        !SensorReadings.Contains(reading)
            ? this with { SensorReadings = SensorReadings.Add(reading) }
            : FinFail<GrowHub>(AlreadyExistsException);
}