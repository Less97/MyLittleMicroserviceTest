using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Services;
using AccountService.Services.MessageSender;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedLibrary;

namespace WebApplication1
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
            services.AddControllersWithViews();
            services.AddSingleton<IMessageSender, MessageSender>();
            services.Configure<RabbitSettings>(Configuration.GetSection("rabbitSettings"));
            services.AddMassTransit(x => { 
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        var settings = Configuration.GetSection("rabbitSettings").Get<RabbitSettings>();
                        //cfg.Host(settings.Url, host =>
                        //{
                        //    host.Username(settings.Username);
                        //    host.Password(settings.Password);
                        //});
                        cfg.Host(settings.Url, (ushort)settings.Port, settings.vHost, "connection", host =>
                        {
                            host.Username(settings.Username);
                            host.Password(settings.Password);
                        });
                    })
                );
            });
            services.AddLogging();
        }

        

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
