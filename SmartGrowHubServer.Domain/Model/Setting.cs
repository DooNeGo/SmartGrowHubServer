using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Exceptions;
using System.Collections.Immutable;

namespace SmartGrowHubServer.Domain.Model;

public sealed record Setting(
    Id<Setting> Id,
    SettingType Type,
    SettingMode Mode,
    ImmutableArray<Component> Components,
    Id<GrowHub> GrowHubId)
{
    private static readonly ItemNotFoundException NotFoundException =
        new(nameof(Component), nameof(Setting));

    private static readonly ItemAlreadyExistsException AlreadyExistsException =
        new(nameof(Component), nameof(Setting));

    private Setting() : this(
        default, default,
        default, [], default)
    { }     // Used by EF Core

    public static Fin<Setting> Create(
        SettingType type, SettingMode mode, Id<GrowHub> hubId,
        Fin<ImmutableArray<Component>> componentsFin) =>
            from components in componentsFin
            select new Setting(
                Common.Id.Create<Setting>(),
                type, mode, components, hubId);

    public Fin<Setting> AddComponent(Component component) =>
        !Components.Contains(component)
            ? this with { Components = Components.Add(component) }
            : FinFail<Setting>(AlreadyExistsException);

    public Fin<Setting> RemoveComponent(Component component)
    {
        int index = Components.IndexOf(component);
        if (index is -1) return FinFail<Setting>(NotFoundException);
        return this with { Components = Components.RemoveAt(index) };
    }
}