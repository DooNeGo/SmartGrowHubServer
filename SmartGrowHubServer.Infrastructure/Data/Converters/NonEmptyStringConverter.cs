using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Infrastructure.Extensions;

namespace SmartGrowHubServer.Infrastructure.Data.Converters;

internal sealed class NonEmptyStringConverter : ValueConverter<NonEmptyString, string>
{
    public NonEmptyStringConverter() : base(
        nonEmpty => nonEmpty.Value,
        str => NonEmptyString.Create(str).IfFail(e => e.Throw<NonEmptyString>())) { }
}