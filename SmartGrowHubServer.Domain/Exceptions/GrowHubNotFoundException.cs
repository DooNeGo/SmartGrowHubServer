namespace SmartGrowHubServer.Domain.Exceptions;

public sealed class GrowHubNotFoundException()
    : Exception("The grow hub was not found in the user account");
