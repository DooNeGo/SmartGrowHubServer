namespace SmartGrowHubServer.Infrastructure.Extensions;

internal static class ExceptionExtensions
{
    public static T Throw<T>(this Exception exception) => throw exception;
}
