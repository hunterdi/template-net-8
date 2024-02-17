using Autofac;
using Autofac.Builder;
using Autofac.Extensions.DependencyInjection;
using Core.Common.Behaviors;
using Core.Common.Extensions;
using Core.Common.Providers;
using Core.Database.Extensions;
using Domain.Common;
using MappingValidation.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Localization;
using System.Globalization;

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

    services.AddLocalization();
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

var supportedCultures = new[] { new CultureInfo("pt-BR"), new CultureInfo("en-US"), new CultureInfo("fr-FR") };

var locationOptions = new RequestLocalizationOptions 
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(supportedCultures[0]),
    SupportedCultures = supportedCultures.ToList(),
    SupportedUICultures = supportedCultures.ToList(),
};

app.UseRequestLocalization(locationOptions);

app.UseAuthorization();

app.MapControllers();

app.Run();
