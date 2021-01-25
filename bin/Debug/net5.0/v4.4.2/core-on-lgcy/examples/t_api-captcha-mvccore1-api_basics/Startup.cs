using System;
using BotDetect;
using BotDetect.Web;
using BotDetect.Web.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Mvc6BasicCaptchaExample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            // Add framework services.
            services.AddMvc();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UsePathBase("/TraditionalAPI/Mvc6BasicCaptchaExample");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Example/Error");
            }
            app.UseSession();
            app.UseStaticFiles();

            //configure BotDetectCaptcha
            app.UseCaptcha(Configuration);
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "areaRoute",
                template: "{area:exists}/{controller=Example}/{action=Index}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Example}/{action=Index}/{id?}");
            });
        }
    }
}
