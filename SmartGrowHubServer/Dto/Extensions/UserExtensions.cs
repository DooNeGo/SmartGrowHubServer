using SmartGrowHubServer.Domain.Model;

namespace SmartGrowHubServer.DTOs.Extensions;

public static class UserExtensions
{
    public static UserDto ToDto(this User user) =>
        new(user.Id, user.UserName, user.Email, user.DisplayName);
}
