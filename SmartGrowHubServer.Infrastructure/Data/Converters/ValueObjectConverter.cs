using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGrowHubServer.Domain.Common.Interfaces;

namespace SmartGrowHubServer.Infrastructure.Data.Converters;

internal sealed class ValueObjectConverter<TModel, TProvider>
    : ValueConverter<TModel, TProvider>
    where TModel : IValueObject<TModel, TProvider>
{
    public ValueObjectConverter() : base(
        value => value.Value,
        provider => Create(provider)) { }

    private static TModel Create(TProvider provider) => TModel.Create(provider).ThrowIfFail();
}