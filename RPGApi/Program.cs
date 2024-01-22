using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Common.Behaviors;
using Core.Common.Extensions;
using Core.Common.Providers;
using Core.Database.Extensions;
using Domain.Common;
using MappingValidation.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

var serviceProvider = new AutofacServiceProviderFactory(providerOptions =>
{
    providerOptions.RegisterAssemblyModules(AppDomain.CurrentDomain.GetAssemblies());
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 512 * 1024 * 1024;
});

builder.Host.UseServiceProviderFactory(serviceProvider)
    .ConfigureServices(services =>
{
    services.Configure<ForwardedHeadersOptions>(options =>
    {
        options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        options.KnownNetworks.Clear();
        options.KnownProxies.Clear();
    });

    services.AddHttpContextAccessor();
    services.Configure<Providers>(builder.Configuration.GetSection("Providers"));
    services.AddProviders();

    services.Configure<TenantSettings>(builder.Configuration.GetSection("Tenant"));
    services.AddScoped<TenantService>();

    services.AddDatabaseContext(builder);
    services.AddLogging(builder =>
    {
        builder.AddDebug();
        builder.AddConsole();
    });

    services.AddMappers();
    services.AddMediatR(e => e.RegisterServicesFromAssemblyContaining<Program>());

    services.AddStorage();

    services.Configure<FormOptions>(options =>
    {
        options.MultipartBodyLengthLimit = 512 * 1024 * 1024;
    });

    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.OperationFilter<TenantIdHeaderSwaggerAttribute>();
    });
});

var app = builder.Build();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();