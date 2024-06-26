namespace SmartGrowHubServer.Domain.Exceptions;

public sealed class InvalidCreatedAtException()
    : Exception("The date must be less than or equal to today's date");