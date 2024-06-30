using SmartGrowHubServer.Domain.Exceptions;

namespace SmartGrowHubServer.Domain.Common;

public readonly record struct UserName : IValueObject<UserName, string>
{
    private const int MinimumLength = 6;

    private static readonly string LengthErrorMessage =
        $"The string must not be shorter than {MinimumLength}";

    private static readonly UserName Default = (UserName)"EmptyUserName";

    private UserName(string str) => Value = str;

    public string Value { get; } = Default;

    public static implicit operator string(UserName userName) => userName.Value;
    public static explicit operator UserName(string value) => Create(value).IfFailThrow();

    public static Try<UserName> Create(string rawValue) => () =>
        NonEmptyLatinString.Create(rawValue.Trim())
            .Bind(IsValidUserName).Match(
                Succ: nonEmpty => new UserName(nonEmpty),
                Fail: ex => new Result<UserName>(new InvalidUserNameException(ex.Message)));

    private static Try<NonEmptyLatinString> IsValidUserName(NonEmptyLatinString value) =>
        () => value.Value.Length >= MinimumLength ? value
            : new Result<NonEmptyLatinString>(new InvalidStringException(LengthErrorMessage));
}