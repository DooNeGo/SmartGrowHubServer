namespace SmartGrowHubServer.Domain.Exceptions;

public sealed class ComponentAlreadyExistsException()
    : Exception("The component already exists in the setting");