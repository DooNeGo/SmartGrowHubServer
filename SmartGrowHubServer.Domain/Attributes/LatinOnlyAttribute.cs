using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SmartGrowHubServer.Domain.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed partial class LatinOnlyAttribute(string errorMessage) : ValidationAttribute
{
    private readonly ValidationResult _failResult = new(errorMessage);

    public Fin<string> IsValid(string value) => GetLatinRegex().IsMatch(value)
        ? value : FinFail<string>(errorMessage);

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) =>
        IsValid(value?.ToString() ?? string.Empty).Match(
            Succ: value => ValidationResult.Success,
            Fail: error => _failResult);

    [GeneratedRegex(@"^[a-zA-Z_0-9@. !#$%^&*()+=]*$", RegexOptions.Compiled)]
    private static partial Regex GetLatinRegex();
}