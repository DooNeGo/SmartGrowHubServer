using LanguageExt;
using SmartGrowHubServer.ApplicationL;
using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Model;
using SmartGrowHubServer.DTOs.Extensions;
using SmartGrowHubServer.Infrastructure;
using SmartGrowHubServer.Requests;
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

Try<User> user = User.Create(
    "Mathew123", "Mathew123",
    "matvey@gmail.com", "DooNeGo",
    Prelude.Try(ImmutableArray<GrowHub>.Empty));

RouteGroupBuilder apiGroup = app.MapGroup("/api");

apiGroup.MapGet("/user", () => user.Match(
    Succ: user => (object)user.ToDto(),
    Fail: ex => Results.BadRequest(ex.Message)));

apiGroup.MapPost("/auth/register", (RegisterRequest request) =>
    User.Create(
        request.UserName,
        request.Password,
        request.Email,
        request.DisplayName,
        Prelude.Try(ImmutableArray<GrowHub>.Empty))
    .Match(
        Succ: user => (object)user.ToDto(),
        Fail: ex => Results.BadRequest(ex.Message)));

app.Run();