using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Infrastructure.Data.Converters;

internal sealed class NonEmptyStringConverter()
    : ValueConverter<NonEmptyString, string>(
        nonEmpty => nonEmpty.Value,
        str => (NonEmptyString)str);