using SmartGrowHubServer.Domain.Exceptions;

namespace SmartGrowHubServer.Domain.Common;

public sealed record UserName
{
    private const int MinimumLength = 6;

    private static readonly string DefaultErrorMessage =
        $"The UserName must not be empty, contain spaces, and be shorter than {MinimumLength}";

    private static readonly string LengthErrorMessage =
        $"The UserName must not be shorter than {MinimumLength}";

    private UserName(NonEmptyString str) => Value = str;

    public NonEmptyString Value { get; }

    public static implicit operator NonEmptyString(UserName userName) => userName.Value;
    public static explicit operator UserName(NonEmptyString value) => Create(value).IfFailThrow();

    public static implicit operator string(UserName userName) => userName.Value;
    public static explicit operator UserName(string value) => Create(value).IfFailThrow();

    public static Try<UserName> Create(NonEmptyString userName) => () =>
        userName.Value.Length >= MinimumLength
            ? new UserName(userName)
            : new Result<UserName>(new InvalidStringException(LengthErrorMessage));

    public static Try<UserName> Create(Try<NonEmptyString> userNameTry) => () =>
        userNameTry.Match(
            Succ: userName => Create(userName).Try(),
            Fail: new Result<UserName>(new InvalidStringException(DefaultErrorMessage)));

    public static Try<UserName> Create(string userNameRaw) =>
        Create(NonEmptyString.Create(userNameRaw));
}