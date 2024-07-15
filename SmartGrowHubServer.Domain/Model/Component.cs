using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Domain.Model;

public readonly record struct Component(
    Id<Component> Id,
    ComponentType Type,
    int Value,
    NonEmptyString Unit)
{
    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(Component other) => Id == other.Id;
}