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
    private User() : this(
        default, default,
        default, default,
        default, [])
    { }    // Used by EF Core

    public static Try<User> Create(
        string userNameRaw, string passwordRaw, string emailRaw,
        string displayNameRaw, Try<ImmutableArray<GrowHub>> hubsTry)
    {
        Try<UserName> userNameTry = UserName.Create(userNameRaw);
        Try<Password> passwordTry = Password.Create(passwordRaw);
        Try<EmailAddress> emailTry = EmailAddress.Create(emailRaw);
        Try<NonEmptyString> displayNameTry = NonEmptyString.Create(displayNameRaw);

        return Create(userNameTry, passwordTry, emailTry, displayNameTry, hubsTry);
    }

    public static Try<User> Create(
        Try<UserName> userNameTry, Try<Password> passwordTry,
        Try<EmailAddress> emailTry, Try<NonEmptyString> displayNameTry,
        Try<ImmutableArray<GrowHub>> hubsTry)
    {
        var result =
            from userName in userNameTry
            from password in passwordTry
            from email in emailTry
            from displayName in displayNameTry
            from hubs in hubsTry
            select (userName, password, email, displayName, hubs);

        return result.Map(tuple => new User(
            Common.Id<User>.Create(),
            tuple.userName, tuple.password,
            tuple.email, tuple.displayName,
            tuple.hubs));
    }
}