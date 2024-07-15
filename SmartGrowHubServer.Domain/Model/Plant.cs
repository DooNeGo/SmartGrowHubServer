using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Domain.Model;

public readonly record struct Plant(
    Id<Plant> Id, NonEmptyString Name)
{
    public static Fin<Plant> Create(string nameRaw) =>
        from name in NonEmptyString.Create(nameRaw)
        select new Plant(Common.Id.Create<Plant>(), name);
}