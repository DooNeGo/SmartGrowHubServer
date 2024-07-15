namespace SmartGrowHubServer.Requests;

public readonly record struct RegisterRequest(
    string? UserName,
    string? Password,
    string? Email,
    string? DisplayName);