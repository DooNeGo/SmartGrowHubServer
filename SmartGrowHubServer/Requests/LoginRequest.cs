namespace SmartGrowHubServer.Requests;

public readonly record struct LoginRequest(
    string? UserName,
    string? Password);