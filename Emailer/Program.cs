using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Emailer
{
    class Program
    {
        private static IConfigurationRoot Configuration;

        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    Configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .AddEnvironmentVariables(prefix: "MYVARS_").Build();
                })
                .ConfigureServices((hostContext, services) =>
                {
                   
                    services.AddSingleton<IConfiguration>(Configuration);
                    services.AddHostedService<EmailerService>();
                    services.Configure<EmailerSettings>(Configuration.GetSection("Emailer"));
                })
                .ConfigureLogging((logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                });
    }
}
