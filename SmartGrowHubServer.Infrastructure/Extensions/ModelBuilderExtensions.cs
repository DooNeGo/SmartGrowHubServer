using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;

namespace SmartGrowHubServer.Infrastructure.Extensions;

internal static class ModelBuilderExtensions
{
    public static ModelBuilder ApplyGlobalConversion<T, TModel, TProvider>(this ModelBuilder modelBuilder)
        where T : ValueConverter<TModel, TProvider>, new()
    {
        var converter = new T();

        IEnumerable<IMutableProperty> properties = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetProperties()
                .Where(p => p.ClrType == typeof(TModel)));

        foreach (IMutableProperty property in properties)
        {
            property.SetValueConverter(converter);
        }

        return modelBuilder;
    }
}