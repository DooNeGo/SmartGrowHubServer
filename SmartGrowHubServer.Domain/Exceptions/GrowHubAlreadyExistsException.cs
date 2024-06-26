namespace SmartGrowHubServer.Domain.Exceptions;

public sealed class GrowHubAlreadyExistsException()
    : Exception("The grow hub already exists in the user account");
