using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Exceptions;
using System.Collections.Immutable;

namespace SmartGrowHubServer.Domain.Model;

public sealed record GrowHub(
    Id<GrowHub> Id,
    ImmutableArray<SensorReading> SensorReadings,
    ImmutableArray<Setting> Settings,
    Option<Id<Plant>> PlantId,
    Id<User> UserId) : IEquatable<GrowHub>
{
    private static readonly ItemAlreadyExistsException AlreadyExistsException =
        new(nameof(SensorReading), nameof(GrowHub));

    private GrowHub() : this(
        default, [], [],
        default, default)
    { }   // Used by EF Core

    public static Fin<GrowHub> Create(
        Fin<ImmutableArray<Setting>> settingsFin, Id<User> userId) =>
            from settings in settingsFin
            select new GrowHub(
                Common.Id.Create<GrowHub>(),
                [], settings, None, userId);

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(GrowHub? other) => other is not null && Id == other.Id;

    public Fin<GrowHub> AddReading(SensorReading reading) =>
        !SensorReadings.Contains(reading)
            ? this with { SensorReadings = SensorReadings.Add(reading) }
            : FinFail<GrowHub>(AlreadyExistsException);
}