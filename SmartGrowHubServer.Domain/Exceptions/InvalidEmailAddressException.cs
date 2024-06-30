namespace SmartGrowHubServer.Domain.Exceptions;

public sealed class InvalidEmailAddressException(string? message)
    : Exception(Prefix + message)
{
    private const string Prefix = "Email: ";
}