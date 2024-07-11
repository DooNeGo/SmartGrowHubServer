using SmartGrowHubServer.Domain.Model;
using System.Collections.Immutable;

namespace SmartGrowHubServer.Infrastructure.Data.Model;

public sealed record SettingDb(
    Ulid Id,
    SettingType Type,
    SettingMode Mode,
    ImmutableArray<ComponentDb> Components,
    GrowHubDb GrowHub)
{
    private SettingDb() : this(
        default!, default,
        default, [], default!)
    { }     // Used by EF Core
}
