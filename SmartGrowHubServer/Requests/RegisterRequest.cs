namespace SmartGrowHubServer.Requests;

public sealed record RegisterRequest(
    string? UserName,
    string? Password,
    string? Email,
    string? DisplayName);