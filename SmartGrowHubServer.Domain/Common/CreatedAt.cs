using LanguageExt.Common;
using SmartGrowHubServer.Domain.Exceptions;

namespace SmartGrowHubServer.Domain.Common;

public readonly record struct CreatedAt
{
    internal static CreatedAt Empty { get; }

    private CreatedAt(DateOnly date) => Date = date;

    public DateOnly Date { get; }

    public static implicit operator DateOnly(CreatedAt createdAt) => createdAt.Date;
    public static explicit operator CreatedAt(DateOnly date) => Create(date).IfFail(e => throw e);

    public static Result<CreatedAt> Create(DateOnly Date) =>
        Date <= DateOnly.FromDateTime(TimeProvider.System.GetLocalNow().Date)
            ? new CreatedAt(Date)
            : new Result<CreatedAt>(new InvalidCreatedAtException());

    public override string ToString() => Date.ToString();
}