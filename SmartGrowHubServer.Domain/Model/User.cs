using LanguageExt.Common;
using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Exceptions;
using System.Collections.Immutable;

namespace SmartGrowHubServer.Domain.Model;

public sealed record User(
    Id<User> Id,
    NonEmptyString UserName,
    NonEmptyString Password,
    EmailAddress Email,
    NonEmptyString DisplayName,
    CreatedAt CreatedAt,
    ImmutableArray<GrowHub> GrowHubs)
{
    private User() : this(
        default,
        NonEmptyString.Empty,
        NonEmptyString.Empty,
        EmailAddress.NotLoaded,
        NonEmptyString.Empty,
        CreatedAt.Empty, [])
    { }    // Used by EF Core

    public Result<User> AddGrowHub(GrowHub hub) => !GrowHubs.Contains(hub)
        ? this with { GrowHubs = GrowHubs.Add(hub) }
        : new Result<User>(new GrowHubAlreadyExistsException());

    public Result<User> RemoveGrowHub(GrowHub hub)
    {
        int index = GrowHubs.IndexOf(hub);
        if (index is -1) return new Result<User>(new GrowHubNotFoundException());
        return this with { GrowHubs = GrowHubs.RemoveAt(index) };
    }
}