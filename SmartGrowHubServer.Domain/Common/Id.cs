namespace SmartGrowHubServer.Domain.Common;

public readonly record struct Id<T>(in Ulid Value)
{
    public static implicit operator Ulid(in Id<T> id) => id.Value;
    public static explicit operator Id<T>(in Ulid ulid) => new(ulid);

    public override string ToString() => Value.ToString();
}

public static class Id
{
    public static Id<T> Create<T>() => new(Ulid.NewUlid());
}