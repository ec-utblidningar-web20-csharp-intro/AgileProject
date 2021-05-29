using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Models;

namespace WeddingApi.Data
{
    public class TestSeed
    {
        private static WeddingDbContext _context { get; set; }
        private static UserManager<IdentityUser> _userManager { get; set; }

        public static Random jadu = new Random();

        
        public async static Task Seeder(IServiceProvider services)
        {
            _context = services.GetRequiredService<WeddingDbContext>();
            _userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();

            await TestSeedWedding();
        }
        public List<WeddingCouple> couples { get; set; }
        static async Task TestSeedWedding()
        {


            
            var FilePathPerson = @".\MOCK_DATA_2.json";
            var Personas = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(FilePathPerson));

            foreach (var person in Personas)
            {
                await _userManager.CreateAsync(person, "test123!");
            }

            var FilePathWedding = @".\MOCK_DATA.json";
            var Weddings = JsonConvert.DeserializeObject<List<Wedding>>(File.ReadAllText(FilePathWedding));


            foreach (var wedding in Weddings)
            {

                await _context.AddAsync(wedding);
                await _context.SaveChangesAsync();
            }

            for (int i = 0; i < 500; i++)
            {
                WeddingCouple weddingCouple = new WeddingCouple()
                {
                    Persons = new List<Person>()
                    {
                        Personas[i],
                        Personas[i + 500]
                        
                    }
                   
                    
                };
                weddingCouple.Wedding = Weddings[i];
                await _context.AddAsync(weddingCouple);
                await _context.SaveChangesAsync();
            };
            

            //1000 bröllop
            
            
            // 1000 Guests
           

            var FilePathMockNames = @".\MOCK_DATA_14.json";
             var MockNames = JsonConvert.DeserializeObject<List<Guests>>(File.ReadAllText(FilePathMockNames));
            
            foreach (var guest in MockNames)
            {
                guest.FriendsOrFamily = (FriendsOrFamily)jadu.Next(0, 2);
                guest.Answer = (Status)jadu.Next(0, 4);
                guest.Side = (MarrierSide)jadu.Next(0, 3);

                var weddings = await _context.Wedding.AsNoTracking().ToListAsync();
                foreach (var wed in weddings)
                {
                    var folktillbröllop = jadu.Next(50, 100);
                    var bröllop = wed;
                    for(int j = 0; j < folktillbröllop; j++)
                        guest.JoinedWedding = bröllop;
                }
                await _context.AddAsync(guest);
            }
            
            await _context.SaveChangesAsync();

        }
    }
}
