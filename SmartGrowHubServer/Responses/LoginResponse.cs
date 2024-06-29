namespace SmartGrowHubServer.Responses;

public sealed record LoginResponse(string DisplayName, string JwtToken);