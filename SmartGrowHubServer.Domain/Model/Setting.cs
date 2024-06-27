using LanguageExt.Common;
using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Exceptions;
using System.Collections.Immutable;

namespace SmartGrowHubServer.Domain.Model;

public sealed record Setting(Id<Setting> Id, SettingType Type,
    ImmutableArray<Component> Components, Id<GrowHub> GrowHubId)
{
    private Setting()
        : this(default, default, [], default) { }     // Used by EF Core

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