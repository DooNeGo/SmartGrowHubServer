using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Exceptions;
using System.Collections.Immutable;

namespace SmartGrowHubServer.Domain.Model;

public readonly record struct Setting(
    Id<Setting> Id,
    SettingType Type,
    SettingMode Mode,
    ImmutableArray<Component> Components)
{
    private static readonly ItemNotFoundException NotFoundException =
        new(nameof(Component), nameof(Setting));

    private static readonly ItemAlreadyExistsException AlreadyExistsException =
        new(nameof(Component), nameof(Setting));

    public static Identity<Setting> Create(
        SettingType type, SettingMode mode,
        ImmutableArray<Component> components) =>
        Id<Setting>(new Setting(
            Common.Id.Create<Setting>(),
            type, mode, components));

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