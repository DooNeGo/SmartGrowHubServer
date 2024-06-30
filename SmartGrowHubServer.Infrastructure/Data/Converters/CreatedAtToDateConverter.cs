using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Infrastructure.Data.Converters;

internal sealed class CreatedAtToDateConverter()
    : ValueConverter<CreatedAt, DateOnly>(
        createdAt => createdAt.Value,
        date => (CreatedAt)date);