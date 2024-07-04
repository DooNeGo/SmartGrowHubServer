using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGrowHubServer.Infrastructure.Data.Converters;

namespace SmartGrowHubServer.Infrastructure.Data.Extensions;

internal static class ModelConfigurationBuilderExtensions
{
    public static ModelConfigurationBuilder AddConversion<TModel, TProvider>(
        this ModelConfigurationBuilder configurationBuilder,
        ValueConverter<TModel, TProvider> converter)
    {
        configurationBuilder
            .Properties<TModel>()
            .HaveConversion(converter.GetType());

        return configurationBuilder;
    }

    public static ModelConfigurationBuilder AddIdConversion<TModel>(
        this ModelConfigurationBuilder configurationBuilder) =>
            configurationBuilder.AddConversion(new IdToByteArrayConverter<TModel>());
}