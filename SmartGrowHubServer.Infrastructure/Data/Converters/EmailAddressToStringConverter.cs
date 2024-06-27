using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Infrastructure.Data.Converters;

internal sealed class EmailAddressToStringConverter()
    : ValueConverter<EmailAddress, string>(
        email => email.Value, 
        str => (EmailAddress)str);