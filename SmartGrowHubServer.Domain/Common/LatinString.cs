using SmartGrowHubServer.Domain.Attributes;
using SmartGrowHubServer.Domain.Common.Interfaces;

namespace SmartGrowHubServer.Domain.Common;

public readonly record struct LatinString : IValueObject<LatinString, string>
{
    private const string ErrorMessage =
        "The value must consist only of Latin letters, digits and special characters";

    private static readonly LatinOnlyAttribute Attribute = new(ErrorMessage);
    private static readonly LatinString Default = (LatinString)"DefaultLatinString";

    private LatinString(string value) => Value = value;

    public static implicit operator string(LatinString value) => value.Value;
    public static explicit operator LatinString(string value) => Create(value).ThrowIfFail();

    public string Value { get; } = Default;

    public static Fin<LatinString> Create(string rawValue) =>
        Attribute.IsValid(rawValue).Map(v => new LatinString(v));

    public override string ToString() => Value;
}