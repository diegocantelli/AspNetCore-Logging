using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // método responsável por configurar os logs
                .ConfigureLogging((context, logging) => 
                {
                    logging.ClearProviders();
                    // context.Configuration.GetSection("Logging")´-> irá buscar as informações contidas no appsettings.json
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
