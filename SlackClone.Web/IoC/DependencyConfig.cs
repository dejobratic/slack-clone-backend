using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SlackClone.Auth.Core.Services;
using SlackClone.Auth.Core.Settings;
using SlackClone.Auth.Core.UseCases;
using SlackClone.Core.Models;
using SlackClone.Core.Services;
using SlackClone.Core.UseCases;
using System;
using System.Threading.Tasks;

namespace SlackClone.Web.IoC
{
    public static class DependencyConfig
    {
        public static void AddDependencies(
            IServiceCollection services,
            IConfiguration configuration)
        {
            AddAuthDependencies(services, configuration);
            AddChatDependencies(services, configuration);
        }

        private static void AddAuthDependencies(
            IServiceCollection services,
            IConfiguration configuration)
        {
            var JWTsettings = new JWTSettings
            {
                Secret = configuration["JWT_SECRET_KEY"]
            };

            services.AddSingleton<IJWTSettings>(JWTsettings);
            services.AddTransient<ITokenGenerator, JWTGenerator>();
            services.AddSingleton<IUserRepository, DummyUserRepository>();
            services.AddTransient<IAuthCommandFactory, AuthCommandFactory>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(JWTsettings.GetSecretAsBytes()),
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Headers["Authorization"];

                        if (!string.IsNullOrEmpty(accessToken))
                        {
                            context.Token = accessToken;
                        }

                        return Task.CompletedTask;
                    }
                };
            });
        }

        private static void AddChatDependencies(
            IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<ITimestampProvider>(provider =>
                new TimestampProvider(DateTimeOffset.UtcNow));

            services.AddTransient<IDateRangeProvider>(provider =>
                new DateRangeProvider(new DateRange(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddDays(1))));


            services.AddSingleton<IChannelRepository, DummyChannelRepository>();
            services.AddSingleton<IMessageRepository, DummyMessageRepository>();

            services.AddTransient<IChatCommandFactory, ChatCommandFactory>();
        }
    }
}
