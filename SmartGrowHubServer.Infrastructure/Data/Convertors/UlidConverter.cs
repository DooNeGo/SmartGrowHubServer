using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SmartGrowHubServer.Infrastructure.Data.Convertors;

internal sealed class UlidConverter() : ValueConverter<Ulid, byte[]>(
    model => model.ToByteArray(),
    provider => new(provider),
    new ConverterMappingHints(size: 16));
