using SmartGrowHubServer.Domain.Attributes;

namespace SmartGrowHubServer.Domain.Common;

public readonly record struct NonEmptyLatinString : IValueObject<NonEmptyLatinString, string>
{
    private const string ErrorMessage =
        "The value must consist only of Latin letters, digits and special characters";

    private readonly static LatinOnlyAttribute Attribute = new(ErrorMessage);
    private readonly static NonEmptyLatinString Default = (NonEmptyLatinString)"Empty";

    private NonEmptyLatinString(string value) => Value = value;

    public string Value { get; } = Default;

    public static implicit operator string(NonEmptyLatinString value) => value.Value;
    public static explicit operator NonEmptyLatinString(string value) => Create(value).IfFailThrow();

    public static Try<NonEmptyLatinString> Create(string rawValue) =>
        NonEmptyString.Create(rawValue)
            .Bind(Attribute.IsValid)
            .Map(a => new NonEmptyLatinString(rawValue));

    public override string ToString() => Value;
}