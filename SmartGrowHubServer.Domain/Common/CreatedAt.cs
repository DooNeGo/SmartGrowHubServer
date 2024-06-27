using LanguageExt.Common;
using SmartGrowHubServer.Domain.Exceptions;
using SmartGrowHubServer.Domain.Extensions;

namespace SmartGrowHubServer.Domain.Common;

public readonly record struct CreatedAt
{
    internal static CreatedAt Empty { get; }

    private CreatedAt(DateOnly date) => Date = date;

    public DateOnly Date { get; }

    public static implicit operator DateOnly(CreatedAt createdAt) => createdAt.Date;
    public static explicit operator CreatedAt(DateOnly date) => Create(date).ThrowIfFail();

    public static Result<CreatedAt> Create(DateOnly Date) =>
        Date <= DateOnly.FromDateTime(TimeProvider.System.GetUtcNow().Date)
            ? new CreatedAt(Date)
            : new Result<CreatedAt>(new InvalidCreatedAtException());

    public override string ToString() => Date.ToString();
}