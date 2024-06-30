using SmartGrowHubServer.Domain.Exceptions;

namespace SmartGrowHubServer.Domain.Common;

public readonly record struct Password : IValueObject<Password, string>
{
    private const int MinimumLength = 8;

    private static readonly string LengthErrorMessage =
        $"The value must not be shorter than {MinimumLength}";

    private static readonly InvalidStringException LengthException =
        new(LengthErrorMessage);

    private static readonly Password Default = (Password)"Password_Was_Empty";

    private Password(string value) => Value = value;

    public string Value { get; } = Default;

    public static implicit operator string(Password value) => value.Value;
    public static explicit operator Password(string value) => Create(value).IfFailThrow();

    public static Try<Password> Create(string rawValue) => () =>
        NonEmptyLatinString.Create(rawValue.Trim())
            .Bind(IsValidPassword).Match(
                Succ: value => new Password(value),
                Fail: ex => new Result<Password>(new InvalidPasswordException(ex.Message)));

    private static Try<NonEmptyLatinString> IsValidPassword(NonEmptyLatinString nonEmpty) =>
        () => nonEmpty.Value.Length >= MinimumLength ? nonEmpty
            : new Result<NonEmptyLatinString>(LengthException);
}
