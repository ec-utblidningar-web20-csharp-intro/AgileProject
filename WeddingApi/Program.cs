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
            TestSeedDb(host).Wait();
            host.Run();


            //testpush


        }

        public static async Task TestSeedDb(IHost host)
        {
            using (IServiceScope scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                //await Seeding.Initialize(services);



                var context = services.GetRequiredService<WeddingDbContext>();
                await context.Database.EnsureCreatedAsync();
                var couple = new WeddingCouple();
                await context.AddAsync(couple);
                var wedding = new Wedding { Couple = couple };
                await context.AddAsync(wedding);
                await context.SaveChangesAsync();
                for (int i = 0; i < 2000; i++)
                {
                    if (i % 2 == 0)
                    {
                        await context.AddAsync(new Guest() { HasPlusOne = false, JoinedWedding = wedding });
                        continue;
                    }
                    await context.AddAsync(new Guest() { HasPlusOne = true, JoinedWedding = wedding });
                }
                await context.AddAsync(new Guest() { HasPlusOne = false, JoinedWedding = wedding });
                await context.AddAsync(new Guest() { HasPlusOne = false, JoinedWedding = wedding });
                await context.AddAsync(new Guest() { HasPlusOne = false, JoinedWedding = wedding });
                await context.SaveChangesAsync();
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
