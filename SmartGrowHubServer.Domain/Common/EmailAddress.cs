using SmartGrowHubServer.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace SmartGrowHubServer.Domain.Common;

public sealed record EmailAddress
{
    private const string ErrorMessage = "Invalid email address";

    private static readonly EmailAddressAttribute Attribute = new();

    internal static EmailAddress NotLoaded { get; } = new("EmailNotLoaded@mail.com");

    private EmailAddress(string value) => Value = value;

    public string Value { get; }

    public static implicit operator string(EmailAddress email) => email.Value;
    public static explicit operator EmailAddress(string value) => Create(value).IfFailThrow();

    public static Try<EmailAddress> Create(string value) => () =>
        !string.IsNullOrEmpty(value) && Attribute.IsValid(value)
            ? new EmailAddress(value)
            : new Result<EmailAddress>(new InvalidStringException(ErrorMessage));

    public override string ToString() => Value;
}