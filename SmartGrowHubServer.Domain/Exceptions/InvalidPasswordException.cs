namespace SmartGrowHubServer.Domain.Exceptions;

public sealed class InvalidPasswordException(string message)
    : Exception(Prefix + message)
{
    private const string Prefix = "Password: ";
}
