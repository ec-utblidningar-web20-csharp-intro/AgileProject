using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Data;
using WeddingApi.Models;

namespace WeddingApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //TestSeedDb(host).Wait();
            host.Run();
        }

        public static async Task TestSeedDb(IHost host)
        {
            using (IServiceScope scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await Seeding.Initialize(services);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
