using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Infrastructure.Data.Converters;

namespace SmartGrowHubServer.Infrastructure.Data.Extensions;

internal static class ModelConfigurationBuilderExtensions
{
    public static ModelConfigurationBuilder AddConversion<TModel, TConverter>(
        this ModelConfigurationBuilder configurationBuilder)
        where TConverter : ValueConverter
    {
        configurationBuilder.Properties<TModel>().HaveConversion<TConverter>();
        return configurationBuilder;
    }

    public static ModelConfigurationBuilder AddIdConversion<TModel>(
        this ModelConfigurationBuilder configurationBuilder) =>
        configurationBuilder.AddConversion<Id<TModel>, IdToByteArrayConverter<TModel>>();
}