namespace SmartGrowHubServer.DTOs;

public sealed record UserDto(
    Ulid Id,
    string UserName,
    string Email,
    string DisplayName);
