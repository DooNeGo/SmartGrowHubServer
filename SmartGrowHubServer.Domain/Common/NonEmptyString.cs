using SmartGrowHubServer.Domain.Exceptions;
using System.Globalization;

namespace SmartGrowHubServer.Domain.Common;

public readonly record struct NonEmptyString : IValueObject<NonEmptyString, string>
{
    private const string ErrorMessage = "The value must not be empty or contain spaces";

    internal static NonEmptyString Default { get; } = (NonEmptyString)"Empty";

    private NonEmptyString(string value) => Value = value;

    public string Value { get; } = Default;

    public static implicit operator string(NonEmptyString value) => value.Value;
    public static explicit operator NonEmptyString(string value) => Create(value).IfFailThrow();

    public static Try<NonEmptyString> Create(string? rawValue) => () =>
        !string.IsNullOrWhiteSpace(rawValue) ? new NonEmptyString(rawValue)
            : new Result<NonEmptyString>(new InvalidStringException(ErrorMessage));

    public override string ToString() => Value;

    public NonEmptyString ToUpper() => new(Value.ToUpper(CultureInfo.CurrentCulture));

    public NonEmptyString ToUpper(CultureInfo culture) => new(Value.ToUpper(culture));

    public NonEmptyString ToLower() => new(Value.ToLower(CultureInfo.CurrentCulture));

    public NonEmptyString ToLower(CultureInfo culture) => new(Value.ToLower(culture));
}