using SmartGrowHubServer.Domain.Common;
using System.Collections.Immutable;

namespace SmartGrowHubServer.Domain.Model;

public sealed record User(
    Id<User> Id,
    UserName UserName,
    NonEmptyString Password,
    EmailAddress Email,
    NonEmptyString DisplayName,
    ImmutableArray<GrowHub> GrowHubs)
{
    private User() : this(
        default,
        default!,
        default!,
        default!,
        default!, [])
    { }    // Used by EF Core

    public static Try<User> Create(string userNameRaw, string passwordRaw, string emailRaw,
        string displayNameRaw, Try<ImmutableArray<GrowHub>> hubsTry) => () =>
        {
            Try<UserName> userNameTry = UserName.Create(userNameRaw);
            Try<NonEmptyString> passwordTry = NonEmptyString.Create(passwordRaw);
            Try<EmailAddress> emailTry = EmailAddress.Create(emailRaw);
            Try<NonEmptyString> displayNameTry = NonEmptyString.Create(displayNameRaw);

            var result =
                from userName in userNameTry
                from password in passwordTry
                from email in emailTry
                from displayName in displayNameTry
                from hubs in hubsTry
                select (userName, password, email, displayName, hubs);

            return result.Match(
                Succ: tuple => new User(
                    Common.Id<User>.Create(),
                    tuple.userName, tuple.password,
                    tuple.email, tuple.displayName,
                    tuple.hubs),
                Fail: ex => new Result<User>(ex));
        };
}