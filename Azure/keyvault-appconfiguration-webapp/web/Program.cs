using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Azure.Identity;
using Microsoft.Azure.AppConfiguration.AspNetCore;

// **BEFORE running the web application, ensure you set the .NET secret.
// The .NETsecret must be executed in the same directory as the .csproj file
// dotnet user-secrets set ConnectionStrings:AppConfig "<your_connection_string>"
//

namespace web
{
    public class Program
    {
        static string appConfigSettings;
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                var appConfigSettings = config.Build();

                config.AddAzureAppConfiguration(options =>
                {
                    options.Connect(appConfigSettings["ConnectionStrings:AppConfig"])
                            .ConfigureKeyVault(keyvault =>
                            {
                                keyvault.SetCredential(new DefaultAzureCredential());
                            });
                });
            })
            .UseStartup<Startup>());
 }
    }
      