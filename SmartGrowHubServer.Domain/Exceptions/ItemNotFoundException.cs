namespace SmartGrowHubServer.Domain.Exceptions;

public sealed class ItemNotFoundException(string itemName, string placeName)
    : Exception($"The {itemName} was not found in the {placeName}");