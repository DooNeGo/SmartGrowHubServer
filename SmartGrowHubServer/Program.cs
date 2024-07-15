using LanguageExt;
using SmartGrowHubServer.ApplicationL;
using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Model;
using SmartGrowHubServer.DTOs.Extensions;
using SmartGrowHubServer.Infrastructure;
using SmartGrowHubServer.Requests;
using SmartGrowHubServer.Responses;
using SmartGrowHubServer.SerializerContext;
using System.Collections.Immutable;

WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain
        .Add(SmartGrowHubSerializerContext.Default);
});

builder.Services.AddApplication().AddInfrastructure();

WebApplication app = builder.Build();

RouteGroupBuilder apiGroup = app.MapGroup("/api");

ImmutableArray<User> users =
[
    User.Create(
        "DooNeGo123",
        "qwertyqwerty",
        "mail@gmail.com",
        "DooNeGo")
    .ThrowIfFail()
];

apiGroup.MapPost("/auth/register", (RegisterRequest request) =>
    User.Create(
        request.UserName ?? string.Empty,
        request.Password ?? string.Empty,
        request.Email ?? string.Empty,
        request.DisplayName ?? string.Empty)
    .Match(
        Succ: user => Results.Ok(user.ToDto()),
        Fail: error => Results.BadRequest(error.Message)));

apiGroup.MapPost("/auth/login", (LoginRequest request) =>
{
    Fin<(UserName userName, Password password)> result =
        from userName in UserName.Create(request.UserName ?? string.Empty)
        from password in Password.Create(request.Password ?? string.Empty)
        select (userName, password);

    return result.Match(
        Succ: tuple => users
            .Find(user =>
                user.UserName == tuple.userName &&
                user.Password == tuple.password)
            .Match(
                Some: user => Results.Ok(
                    new LoginResponse(
                        user.ToDto(),
                        "123qwerewfcwdc123123")),
                None: Results.NotFound()),
        Fail: error => Results.BadRequest(error.Message));
});

app.Run();