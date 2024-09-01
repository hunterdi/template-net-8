using ConsumerRabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static async Task Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        builder.Environment.ContentRootPath = Directory.GetCurrentDirectory();
        builder.Configuration.AddJsonFile("hostsettings.json", optional: true);
        builder.Configuration.AddEnvironmentVariables();

        builder.Services.AddHostedService<Worker>();

        using IHost host = builder.Build();

        await host.RunAsync();
    }
}