﻿using Infrastructure.Behaviors.Middleware;
using Infrastructure.Behaviors.Middlewares;
using Infrastructure.Behaviors.Middlewares.GlobalException;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Globalization;

namespace Infrastructure.Behaviors.Extensions.Configurations
{
    public static class WebApplicationConfigurationExtension
    {
        public static async Task<WebApplication> AddConfiguration(this WebApplication app, Task runSeed)
        {
            if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();
            else app.UseHsts();

            app.UseSerilogRequestLogging(opts => opts.EnrichDiagnosticContext = LoggerConfigurationrExtension.EnrichFromRequest);

            app.UseExceptionHandler(_ => { });
            app.UseMiddleware<RequestAuditMiddleware>();
            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseMiddleware<OperationCanceledMiddleware>();

            await runSeed;

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();

            var supportedCultures = new[] { new CultureInfo("pt-BR"), new CultureInfo("en-US"), new CultureInfo("fr-FR") };
            var locationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(supportedCultures[0]),
                SupportedCultures = supportedCultures.ToList(),
                SupportedUICultures = supportedCultures.ToList(),
            };
            app.UseRequestLocalization(locationOptions);
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
