using SmartGrowHubServer.Domain.Common;
using System.Collections.Immutable;

namespace SmartGrowHubServer.Domain.Model;

public sealed record User(
    Id<User> Id,
    UserName UserName,
    Password Password,
    EmailAddress Email,
    NonEmptyString DisplayName,
    ImmutableArray<GrowHub> GrowHubs)
{
    public static Fin<User> Create(
        string userNameRaw, string passwordRaw,
        string emailRaw, string displayNameRaw) =>
            from userName in UserName.Create(userNameRaw)
            from password in Password.Create(passwordRaw)
            from email in EmailAddress.Create(emailRaw)
            from displayName in NonEmptyString.Create(displayNameRaw)
            select new User(
                Common.Id.Create<User>(),
                userName, password,
                email, displayName, []);
}