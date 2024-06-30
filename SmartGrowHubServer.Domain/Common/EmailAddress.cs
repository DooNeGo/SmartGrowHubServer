using SmartGrowHubServer.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace SmartGrowHubServer.Domain.Common;

public readonly record struct EmailAddress : IValueObject<EmailAddress, string>
{
    private const string ErrorMessage = "Invalid email address";

    private static readonly EmailAddressAttribute Attribute = new();
    private static readonly InvalidStringException Exception = new(ErrorMessage);
    private static readonly EmailAddress Default = (EmailAddress)"EmptyEmail@empty.com";

    private EmailAddress(string value) => Value = value;

    public string Value { get; } = Default;

    public static implicit operator string(EmailAddress email) => email.Value;
    public static explicit operator EmailAddress(string value) => Create(value).IfFailThrow();

    public static Try<EmailAddress> Create(string rawValue) => () =>
        NonEmptyLatinString.Create(rawValue.Trim()).Bind(IsValidEmailAddress).Match(
            Succ: value => new EmailAddress(value),
            Fail: ex => new Result<EmailAddress>(new InvalidEmailAddressException(ex.Message)));

    public override string ToString() => Value;

    private static Try<NonEmptyLatinString> IsValidEmailAddress(NonEmptyLatinString latinString) =>
        () => Attribute.IsValid((string)latinString) ? latinString
            : new Result<NonEmptyLatinString>(Exception);
}