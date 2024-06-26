namespace SmartGrowHubServer.Domain.Model;

public readonly record struct ComponentId(Ulid Value)
{
    public static ComponentId Empty { get; }

    public static ComponentId Create() => new(Ulid.NewUlid());
}

public sealed record Component(ComponentId Id, ComponentType Type, SettingId SettingId)
    : IEquatable<Component>
{
    private Component()
        : this(ComponentId.Empty, default, SettingId.Empty) { } // Used by EF Core

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(Component? other) => other is not null && Id == other.Id;
}