using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Domain.Model;

public sealed record Plant(Id<Plant> Id, NonEmptyString Name, Id<GrowHub> GrowHubId)
{
    private Plant()
        : this(default, NonEmptyString.Empty, default) { }  // Used by EF Core
}