using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Infrastructure.Data.Converters;

internal sealed class CreatedAtToDateConverter()
    : ValueConverter<CreatedAt, DateOnly>(
        createAt => createAt.Date,
        date => (CreatedAt)date);