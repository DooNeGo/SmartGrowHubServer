namespace SmartGrowHubServer.Infrastructure.Data.Model;

public sealed record PlantDb(
    Ulid Id, string Name)
{
    private PlantDb() : this(
        default!, default!)
    { }  // Used by EF Core
}