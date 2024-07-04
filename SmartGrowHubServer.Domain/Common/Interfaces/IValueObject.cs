namespace SmartGrowHubServer.Domain.Common.Interfaces;

public interface IValueObject<T, TValue> where T : IValueObject<T, TValue>
{
    TValue Value { get; }

    static abstract Fin<T> Create(TValue rawValue);
}