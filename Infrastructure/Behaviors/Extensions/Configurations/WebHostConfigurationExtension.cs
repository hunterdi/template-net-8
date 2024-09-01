using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Infrastructure.Behaviors.Extensions.Configurations
{
    public static class WebHostConfigurationExtension
    {
        public static IWebHostBuilder AddConfiguration(this IWebHostBuilder builder)
        {
            builder.ConfigureKestrel((_, options) =>
            {
                options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
                options.Limits.MaxRequestBodySize = 512 * 1024 * 1024;

                var portEnv = Environment.GetEnvironmentVariable("ASPNETCORE_HTTP_PORT");
                int.TryParse(portEnv, out int port);

                options.ListenAnyIP(port, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
                    listenOptions.UseHttps();
                });
            });

            return builder;
        }
    }
}
