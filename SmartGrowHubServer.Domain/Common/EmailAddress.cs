using LanguageExt.Common;
using SmartGrowHubServer.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace SmartGrowHubServer.Domain.Common;

public readonly record struct EmailAddress
{
    private static readonly EmailAddressAttribute Attribute = new();

    internal static EmailAddress NotLoaded { get; } = new("EmailNotLoaded@mail.com");

    private EmailAddress(string value) => Value = value;

    public string Value { get; }

    public static implicit operator string(EmailAddress email) => email.Value;
    public static explicit operator EmailAddress(string value) => Create(value).IfFail(e => throw e);

    public static Result<EmailAddress> Create(string value) =>
        !string.IsNullOrEmpty(value) && Attribute.IsValid(value)
            ? new EmailAddress(value)
            : new Result<EmailAddress>(new InvalidEmailAddressException());

    public override string ToString() => Value;
}