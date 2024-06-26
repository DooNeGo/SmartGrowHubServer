using LanguageExt.Common;
using SmartGrowHubServer.Domain.Exceptions;
using System.Collections.Immutable;

namespace SmartGrowHubServer.Domain.Model;

public readonly record struct SettingId(Ulid Value)
{
    public static SettingId Empty { get; }

    public static SettingId Create() => new(Ulid.NewUlid());
}

public sealed record Setting(SettingId Id, SettingType Type,
    ImmutableArray<Component> Components, GrowHubId GrowHubId)
{
    private Setting() : this(
        SettingId.Empty,
        default, [],
        GrowHubId.Empty) { }    // Used by EF Core

    public Result<Setting> AddComponent(Component component) =>
        !Components.Contains(component)
            ? this with { Components = Components.Add(component) }
            : new Result<Setting>(new ComponentAlreadyExistsException());

    public Result<Setting> RemoveComponent(Component component)
    {
        int index = Components.IndexOf(component);
        if (index is -1) return new Result<Setting>(new ComponentNotFoundException());
        return this with { Components = Components.RemoveAt(index) };
    }
}