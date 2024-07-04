using SmartGrowHubServer.Domain.Common.Interfaces;

namespace SmartGrowHubServer.Domain.Common;

public readonly record struct NonEmptyString : IValueObject<NonEmptyString, string>
{
    private const string ErrorMessage = "The value must not be empty or contain only spaces";

    internal static NonEmptyString Default { get; } = (NonEmptyString)"Empty";

    private NonEmptyString(string value) => Value = value;

    public string Value { get; } = Default;

    public static implicit operator string(NonEmptyString value) => value.Value;
    public static explicit operator NonEmptyString(string value) => Create(value).ThrowIfFail();

    public static Fin<NonEmptyString> Create(string rawValue) =>
        !string.IsNullOrWhiteSpace(rawValue) ? new NonEmptyString(rawValue)
            : FinFail<NonEmptyString>(ErrorMessage);

    public override string ToString() => Value;
}