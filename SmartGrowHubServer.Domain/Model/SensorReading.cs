using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Domain.Model;

public sealed record SensorReading(
    Id<SensorReading> Id,
    SensorType Type,
    NonEmptyString Value,
    NonEmptyString Unit,
    CreatedAt CreatedAt,
    Id<GrowHub> GrowHubId)
{
    private SensorReading() : this(
        default, default,
        default, default,
        default, default)
    { }    // Used by EF Core

    public static Fin<SensorReading> Create(
        SensorType type, string valueRaw, string unitRaw,
        DateOnly createdAtRaw, Id<GrowHub> hubId) =>
            from value in NonEmptyString.Create(valueRaw)
            from unit in NonEmptyString.Create(unitRaw)
            from createdAt in CreatedAt.Create(createdAtRaw)
            select new SensorReading(
                Common.Id.Create<SensorReading>(),
                type, value, unit,
                createdAt, hubId);
}