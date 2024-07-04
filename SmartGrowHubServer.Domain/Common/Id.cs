namespace SmartGrowHubServer.Domain.Common;

public readonly record struct Id<T>(Ulid Value)
{
    public static implicit operator Ulid(Id<T> id) => id.Value;

    public override string ToString() => Value.ToString();
}

public static class Id
{
    public static Id<T> Create<T>() => new(Ulid.NewUlid());
}