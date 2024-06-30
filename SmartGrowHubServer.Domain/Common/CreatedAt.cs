using SmartGrowHubServer.Domain.Exceptions;

namespace SmartGrowHubServer.Domain.Common;

public readonly record struct CreatedAt : IValueObject<CreatedAt, DateOnly>
{
    private static readonly TimeProvider TimeProvider = TimeProvider.System;

    private CreatedAt(DateOnly date) => Value = date;

    public DateOnly Value { get; }

    public static implicit operator DateOnly(CreatedAt createdAt) => createdAt.Value;
    public static explicit operator CreatedAt(DateOnly date) => Create(date).IfFailThrow();

    public static Try<CreatedAt> Create(DateOnly rawValue) => () =>
        rawValue <= DateOnly.FromDateTime(TimeProvider.GetUtcNow().Date)
            ? new CreatedAt(rawValue)
            : new Result<CreatedAt>(new InvalidCreatedAtException());

    public override string ToString() => Value.ToString();
}