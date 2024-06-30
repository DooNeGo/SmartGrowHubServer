namespace SmartGrowHubServer.Domain.Common;

public interface IValueObject<T, TValue> where T : IValueObject<T, TValue>
{
    TValue Value { get; }

    static virtual implicit operator TValue(T value) => value.Value;
    static virtual explicit operator T(TValue value) => T.Create(value).IfFailThrow();

    static abstract Try<T> Create(TValue rawValue);
}
