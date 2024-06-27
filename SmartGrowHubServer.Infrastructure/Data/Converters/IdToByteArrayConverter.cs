using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Infrastructure.Data.Converters;

internal sealed class IdToByteArrayConverter<T>()
    : ValueConverter<Id<T>, byte[]>(
        id => id.Value.ToByteArray(),
        array => new Id<T>(new Ulid(array)),
        new ConverterMappingHints(size: 16));