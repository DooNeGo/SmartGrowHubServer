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
}