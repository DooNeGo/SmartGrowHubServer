namespace SmartGrowHubServer.Domain.Exceptions;

public sealed class InvalidUserNameException(string message)
    : Exception(Prefix + message)
{
    private const string Prefix = "UserName: ";
}
