﻿using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Domain.Model;

public readonly record struct SensorReading(
    Id<SensorReading> Id,
    SensorType Type,
    NonEmptyString Value,
    NonEmptyString Unit,
    CreatedAt CreatedAt)
{
    public static Fin<SensorReading> Create(
        SensorType type, string valueRaw,
        string unitRaw, DateOnly createdAtRaw) =>
            from value in NonEmptyString.Create(valueRaw)
            from unit in NonEmptyString.Create(unitRaw)
            from createdAt in CreatedAt.Create(createdAtRaw)
            select new SensorReading(
                Common.Id.Create<SensorReading>(),
                type, value, unit, createdAt);
}