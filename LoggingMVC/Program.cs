using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // obtendo o servi�o do ILogger
            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Aplica��o iniciada");
            //CreateHostBuilder(args).Build().Run();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // m�todo respons�vel por configurar os logs
                .ConfigureLogging((context, logging) => 
                {
                    logging.ClearProviders();
                    // context.Configuration.GetSection("Logging")�-> ir� buscar as informa��es contidas no appsettings.json
                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                    logging.AddDebug();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
