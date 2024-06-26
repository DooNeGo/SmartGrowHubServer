using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SmartGrowHubServer.Infrastructure.Data.Converters;

internal sealed class UlidToByteArrayConverter : ValueConverter<Ulid, byte[]>
{
    private static readonly ConverterMappingHints defaultHints = new(size: 16);

    public UlidToByteArrayConverter() : base(
            ulid => ulid.ToByteArray(),
            array => Ulid.Parse(array),
            defaultHints)
    { }
}