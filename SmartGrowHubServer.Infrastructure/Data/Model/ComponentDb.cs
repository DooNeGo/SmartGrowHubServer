using SmartGrowHubServer.Domain.Model;

namespace SmartGrowHubServer.Infrastructure.Data.Model;

public sealed record ComponentDb(
    Ulid Id,
    ComponentType Type,
    int Value,
    string Unit,
    Ulid SettingId,
    SettingDb Setting)
{
    private ComponentDb() : this(
        default!, default,
        default, default!,
        default, default!)
    { } // Used by EF Core
}
