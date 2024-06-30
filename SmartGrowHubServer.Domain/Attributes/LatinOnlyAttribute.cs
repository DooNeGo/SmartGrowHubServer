using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SmartGrowHubServer.Domain.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed partial class LatinOnlyAttribute(string errorMessage) : ValidationAttribute
{
    private readonly ValidationResult _failResult = new(errorMessage);
    private readonly InvalidStringException _exception = new(errorMessage);

    public Try<NonEmptyString> IsValid(NonEmptyString value) => () =>
        GetLatinRegex().IsMatch(value) ? value
            : new Result<NonEmptyString>(_exception);

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) =>
        NonEmptyString.Create(value?.ToString()).Bind(IsValid).Match(
            Succ: a => ValidationResult.Success,
            Fail: _failResult);

    [GeneratedRegex(@"^[a-zA-Z_0-9@.]*$", RegexOptions.Compiled)]
    private static partial Regex GetLatinRegex();
}