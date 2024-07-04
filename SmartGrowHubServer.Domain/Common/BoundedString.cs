using SmartGrowHubServer.Domain.Common.Interfaces;

namespace SmartGrowHubServer.Domain.Common;

public readonly record struct BoundedString : IValueObject<BoundedString, string>
{
    private BoundedString(string value) => Value = value;

    public string Value { get; }

    public static implicit operator string(BoundedString value) => value.Value;
    public static explicit operator BoundedString(string value) => Create(value).ThrowIfFail();

    public static Fin<BoundedString> Create(string rawValue) =>
        new BoundedString(rawValue);

    public static Fin<BoundedString> Create(
        string rawValue, Option<NonNegativeInteger> minLength,
        Option<NonNegativeInteger> maxLength) =>
            Create(rawValue)
                .Bind(bounded => ValidateMinLength(bounded, minLength))
                .Bind(bounded => ValidateMaxLength(bounded, maxLength));

    private static Fin<BoundedString> ValidateMaxLength(
        BoundedString bounded, Option<NonNegativeInteger> maxLengthOption) =>
            ValidateLength(bounded, maxLengthOption, GetMaxLengthErrorMessage,
                (str, max) => str.Length <= max);

    private static Fin<BoundedString> ValidateMinLength(
        BoundedString bounded,Option<NonNegativeInteger> minLengthOption) =>
            ValidateLength(bounded, minLengthOption, GetMinLengthErrorMessage,
                (str, min) => str.Length >= min || str.Length is 0);

    private static Fin<BoundedString> ValidateLength(
        BoundedString bounded, Option<NonNegativeInteger> lengthOption,
        Func<int, string> formatError,
        Func<string, NonNegativeInteger, bool> isValid) =>
            lengthOption.Match(
                Some: length => isValid(bounded, length)
                    ? FinSucc(bounded)
                    : FinFail<BoundedString>(formatError(length)),
                None: bounded);

    private static string GetMinLengthErrorMessage(int minLength) =>
        $"The value must not be shorter than {minLength}";
    private static string GetMaxLengthErrorMessage(int maxLength) =>
        $"The value must not be longer than {maxLength}";

    public override string ToString() => Value;
}