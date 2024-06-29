using SmartGrowHubServer.Domain.Exceptions;

namespace SmartGrowHubServer.Domain.Common;

public sealed record CreatedAt
{
    internal static CreatedAt Empty { get; } = new(default(DateOnly));

    private CreatedAt(DateOnly date) => Date = date;

    public DateOnly Date { get; }

    public static implicit operator DateOnly(CreatedAt createdAt) => createdAt.Date;
    public static explicit operator CreatedAt(DateOnly date) => Create(date).IfFailThrow();

    public static Try<CreatedAt> Create(DateOnly Date) => () =>
        Date <= DateOnly.FromDateTime(TimeProvider.System.GetUtcNow().Date)
            ? new CreatedAt(Date)
            : new Result<CreatedAt>(new InvalidCreatedAtException());

    public override string ToString() => Date.ToString();
}