﻿using SmartGrowHubServer.Domain.Common;

namespace SmartGrowHubServer.Domain.Model;

public readonly record struct User(
    Id<User> Id,
    UserName UserName,
    Password Password,
    EmailAddress Email,
    NonEmptyString DisplayName)
{
    public static Fin<User> Create(
        string userNameRaw, string passwordRaw,
        string emailRaw, string displayNameRaw) =>
            from userName in UserName.Create(userNameRaw)
            from password in Password.Create(passwordRaw)
            from email in EmailAddress.Create(emailRaw)
            from displayName in NonEmptyString.Create(displayNameRaw)
            select new User(
                Common.Id.Create<User>(),
                userName, password,
                email, displayName);
}