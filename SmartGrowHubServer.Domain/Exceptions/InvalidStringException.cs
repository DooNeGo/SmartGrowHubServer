namespace SmartGrowHubServer.Domain.Exceptions;

public sealed class InvalidStringException()
    : Exception("The string must not be empty or contain spaces");