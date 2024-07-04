using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Domain.Model;

public sealed record Component(
    Id<Component> Id,
    ComponentType Type,
    int Value,
    NonEmptyString Unit,
    Id<Setting> SettingId) : IEquatable<Component>
{
    private Component() : this(
        default, default,
        default, default,
        default) { } // Used by EF Core

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(Component? other) => other is not null && Id == other.Id;
}