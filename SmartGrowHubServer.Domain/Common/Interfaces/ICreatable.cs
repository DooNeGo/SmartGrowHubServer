namespace SmartGrowHubServer.Domain.Common.Interfaces;

public interface ICreatable<out T, in TValue>
{
    public static abstract T Create(TValue rawValue);
}