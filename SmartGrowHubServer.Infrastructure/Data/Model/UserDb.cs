using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Model;
using System.Collections.Immutable;

namespace SmartGrowHubServer.Infrastructure.Data.Model;

public sealed record UserDb(
    Ulid Id,
    string UserName,
    string Password,
    string Email,
    string DisplayName,
    ImmutableArray<GrowHubDb> GrowHubs)
{
    private UserDb() : this(
        default!, default!,
        default!, default!,
        default!, [])
    { }    // Used by EF Core

    public Fin<User> ToDomain() =>
        User.Create(new Id<User>(Id), UserName,
            Password, Email, DisplayName);
}