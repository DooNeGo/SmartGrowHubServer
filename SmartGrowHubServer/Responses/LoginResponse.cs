using SmartGrowHubServer.DTOs;

namespace SmartGrowHubServer.Responses;

public readonly record struct LoginResponse(UserDto User, string JwtToken);