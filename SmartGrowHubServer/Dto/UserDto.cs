namespace SmartGrowHubServer.DTOs;

public readonly record struct UserDto(
    Ulid Id,
    string UserName,
    string Email,
    string DisplayName);
