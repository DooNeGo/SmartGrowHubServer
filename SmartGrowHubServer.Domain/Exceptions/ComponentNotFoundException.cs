namespace SmartGrowHubServer.Domain.Exceptions;

public sealed class ComponentNotFoundException()
    : Exception("The component was not found in the setting");
