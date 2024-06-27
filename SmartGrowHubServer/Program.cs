using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Extensions;
using SmartGrowHubServer.Domain.Model;
using SmartGrowHubServer.SerializerContext;

namespace SmartGrowHubServer;

public sealed class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain
                .Add(SmartGrowHubSerializerContext.Default);
        });

        WebApplication app = builder.Build();

        app.MapGet("/", () => Id.Create<User>().ToString());

        app.MapGet("/users", () => new User(
            Id.Create<User>(),
            NonEmptyString.Create("Mathew123").ThrowIfFail(),
            NonEmptyString.Create("qwerty123").ThrowIfFail(),
            EmailAddress.Create("mat@gmail.com").ThrowIfFail(),
            NonEmptyString.Create("Mathew").ThrowIfFail(),
            CreatedAt.Create(DateOnly.FromDateTime(DateTime.Now)).ThrowIfFail(),
            []));

        app.Run();
    }
}