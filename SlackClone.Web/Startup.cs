using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SlackClone.Core.Models;
using SlackClone.Core.Services;
using SlackClone.Core.Settings;
using SlackClone.Core.UseCases;
using SlackClone.Web.Hubs;
using System;

namespace SlackClone.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:3000", "https://localhost:3000");
                });
            });

            services.AddSingleton<IJWTSettings>(provider =>
                new JWTSettings
                {
                    Secret = Configuration["JWT_SECRET_KEY"]
                });

            services.AddTransient<ITimestampProvider>(provider =>
                new TimestampProvider(DateTimeOffset.UtcNow));

            services.AddTransient<IDateRangeProvider>(provider =>
                new DateRangeProvider(new DateRange(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddDays(1))));

            services.AddTransient<ITokenGenerator, JWTGenerator>();

            services.AddSingleton<IUserRepository, DummyUserRepository>();
            services.AddSingleton<IChannelRepository, DummyChannelRepository>();
            services.AddSingleton<IMessageRepository, DummyMessageRepository>();

            services.AddTransient<IAuthCommandFactory, AuthCommandFactory>();
            services.AddTransient<IChatCommandFactory, ChatCommandFactory>();

            services.AddSignalR();
            services.AddControllers().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("hubs/chat");
                endpoints.MapControllers();
            });
        }
    }
}
