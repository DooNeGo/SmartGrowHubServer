namespace SmartGrowHubServer.Domain.Common;

public readonly record struct Id<T>(Ulid Value)
{
    public static implicit operator Ulid(Id<T> id) => id.Value;

    public static Id<T> Create() => new(Ulid.NewUlid());

    public override string ToString() => Value.ToString();
}

public readonly record struct Id(Ulid Value)
{
    public static Id Empty { get; }

    public static Id Create() => new(Ulid.NewUlid());

    public static Id<T> Create<T>() => new(Ulid.NewUlid());
}