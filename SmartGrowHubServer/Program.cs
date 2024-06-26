namespace SmartGrowHubServer;

public sealed class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);
        WebApplication app = builder.Build();
        app.Run();
    }
}