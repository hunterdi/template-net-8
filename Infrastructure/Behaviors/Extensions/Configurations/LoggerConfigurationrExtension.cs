using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Filters;
using Serilog.Formatting.Json;
using Destructurama;
using SerilogTracing;
using Serilog.Events;

namespace Infrastructure.Behaviors.Extensions.Configurations
{
    public static class LoggerConfigurationrExtension
    {
        public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, IConfiguration configuration, string applicationName)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.WithProperty("APP", $"{applicationName} - {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}")
                .Enrich.FromLogContext()
                .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
                .Filter.ByExcluding(e => e.MessageTemplate.Text.Contains("specific error"))
                .WriteTo.Console(new JsonFormatter(renderMessage: true), LogEventLevel.Debug)
                //.WriteTo.Console(Formatters.CreateConsoleTextFormatter(TemplateTheme.Code))
                //"[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception} HTTP {RequestMethod} {RequestPath} ({UserId}{id}) responded {StatusCode} in {Elapsed:0.0000}ms"
                .Destructure.UsingAttributes()
                .CreateLogger();

            using var _ = new ActivityListenerConfiguration().TraceToSharedLogger();

            builder.Logging.ClearProviders();
            builder.Logging.Configure(options =>
            {
                options.ActivityTrackingOptions = ActivityTrackingOptions.TraceId | ActivityTrackingOptions.SpanId;
            });
            builder.Host.UseSerilog(Log.Logger, true);

            return builder;
        }

        public static void EnrichFromRequest(IDiagnosticContext diagnosticContext, HttpContext httpContext)
        {
            diagnosticContext.Set("UserName", httpContext?.User?.Identity?.Name);
            diagnosticContext.Set("ClientIP", httpContext?.Connection?.RemoteIpAddress?.ToString());
            diagnosticContext.Set("UserAgent", httpContext?.Request?.Headers["User-Agent"].FirstOrDefault());
            diagnosticContext.Set("Resource", httpContext?.GetMetricsCurrentResourceName());
        }

        public static string? GetMetricsCurrentResourceName(this HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            var endpoint = httpContext.Features.Get<IEndpointFeature>()?.Endpoint;
            var endpointName = endpoint?.Metadata.GetMetadata<EndpointNameMetadata>()?.EndpointName;

            return endpointName;
        }
    }
}
