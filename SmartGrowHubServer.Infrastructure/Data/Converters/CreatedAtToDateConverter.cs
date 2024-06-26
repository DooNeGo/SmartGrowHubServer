using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Infrastructure.Extensions;

namespace SmartGrowHubServer.Infrastructure.Data.Converters;

internal sealed class CreatedAtToDateConverter : ValueConverter<CreatedAt, DateOnly>
{
    public CreatedAtToDateConverter() : base(
        createAt => createAt.Date,
        date => CreatedAt.Create(date).IfFail(e => e.Throw<CreatedAt>())) { }
}
