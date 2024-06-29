namespace SmartGrowHubServer.Domain.Exceptions;

public sealed class SensorReadingAlreadyExistsException()
    : Exception("The sensor reading already exists in the grow hub");