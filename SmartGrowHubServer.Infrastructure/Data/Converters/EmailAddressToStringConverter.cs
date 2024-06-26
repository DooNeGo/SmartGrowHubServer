using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Infrastructure.Extensions;

namespace SmartGrowHubServer.Infrastructure.Data.Converters;

internal sealed class EmailAddressToStringConverter : ValueConverter<EmailAddress, string>
{
    public EmailAddressToStringConverter() : base(
        email => email.Value, 
        str => EmailAddress.Create(str).IfFail(e => e.Throw<EmailAddress>())) { }
}