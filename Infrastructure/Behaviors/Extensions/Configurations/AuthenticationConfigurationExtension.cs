using Infrastructure.Database;
using Domain.Behaviors;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.Behaviors.Extensions.Configurations
{
    public static class AuthenticationConfigurationExtension
    {
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services)
        {
            //var serviceProvider = services.BuildServiceProvider() ?? throw new Exception("");
            //var authentication = serviceProvider.GetRequiredService<IOptions<AuthenticationSettings>>() ?? throw new Exception("");

            var authentication = services.GetService<IOptions<AuthenticationSettings>>() ?? throw new Exception("");

            services.Configure<BearerTokenOptions>(options =>
            {
                options.BearerTokenExpiration = TimeSpan.FromDays(authentication.Value.BearerTokenExpiration);
            });
            services.AddIdentity<User, IdentityRole<long>>((options) =>
            {
                // Password settings.
                options.Password.RequireDigit = authentication.Value.RequireDigit;
                options.Password.RequireLowercase = authentication.Value.RequireLowercase;
                options.Password.RequireNonAlphanumeric = authentication.Value.RequireNonAlphanumeric;
                options.Password.RequireUppercase = authentication.Value.RequireUppercase;
                options.Password.RequiredLength = authentication.Value.RequiredLength;
                options.Password.RequiredUniqueChars = authentication.Value.RequiredUniqueChars;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(authentication.Value.DefaultLockoutTimeSpan);
                options.Lockout.MaxFailedAccessAttempts = authentication.Value.MaxFailedAccessAttempts;
                options.Lockout.AllowedForNewUsers = authentication.Value.AllowedForNewUsers;

                // User settings.
                options.User.AllowedUserNameCharacters = authentication.Value.AllowedUserNameCharacters;
                options.User.RequireUniqueEmail = authentication.Value.RequireUniqueEmail;
            }).AddEntityFrameworkStores<PostgresDBContext>();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = authentication.Value.ValidateIssuer,
                        ValidateAudience = authentication.Value.ValidateAudience,
                        ValidateLifetime = authentication.Value.ValidateLifetime,
                        ValidateIssuerSigningKey = authentication.Value.ValidateIssuerSigningKey,
                        ValidIssuer = authentication.Value.ValidIssuer,
                        ValidAudience = authentication.Value.ValidAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authentication.Value.IssuerSigningKey))
                    };
                });
            services.AddAuthorizationBuilder();

            return services;
        }
    }
}
