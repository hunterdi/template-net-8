using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using Infrastructure.Behaviors.Extensions.Configurations;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.AddSerilog(builder.Configuration, "RPG Application");

    Log.Information("APP[EXECUTING]");

    var serviceProvider = new AutofacServiceProviderFactory(builderOptions =>
    {
        builderOptions.RegisterAssemblyModules(AppDomain.CurrentDomain.GetAssemblies());
    });

    builder.WebHost.AddConfiguration();

    builder.Host
        .UseServiceProviderFactory(serviceProvider)
        .ConfigureServices(services =>
    {
        services.AddConfiguration(builder);
    });

    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        await app.AddConfiguration(Seed.Extensions.Seed.SeedDataAsync(services));
    }

    app.Run();
}
catch (Exception ex) when (ex is not HostAbortedException && ex.Source != "Microsoft.EntityFrameworkCore.Design")
{
    Log.Fatal(ex, "APP[EXCEPTION]");
}
finally
{
    Log.Information("APP[END]");
    await Log.CloseAndFlushAsync();
}