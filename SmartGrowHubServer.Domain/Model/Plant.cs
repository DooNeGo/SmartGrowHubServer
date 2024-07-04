﻿using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Domain.Model;

public sealed record Plant(
    Id<Plant> Id,
    NonEmptyString Name,
    Id<GrowHub> GrowHubId)
{
    private Plant() : this(
        default,
        NonEmptyString.Default,
        default)
    { }  // Used by EF Core

    public static Fin<Plant> Create(string nameRaw, Id<GrowHub> hubId) =>
        from name in NonEmptyString.Create(nameRaw)
        select new Plant(
            Common.Id.Create<Plant>(),
            name, hubId);
}