using SmartGrowHubServer.DTOs;

namespace SmartGrowHubServer.Responses;

public sealed record LoginResponse(UserDto User, string JwtToken);