using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Domain.Model;

public readonly record struct PlantId(Ulid Value)
{
    public static PlantId Empty { get; }

    public static PlantId Create() => new(Ulid.NewUlid());
}

public sealed record Plant(PlantId Id, NonEmptyString Name, GrowHubId GrowHubId)
{
    private Plant() : this(
        PlantId.Empty,
        NonEmptyString.Empty,
        GrowHubId.Empty) { }    // Used by EF Core
}