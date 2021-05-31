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
              
                await _context.AddAsync(weddingCouple);
                await _context.SaveChangesAsync();
            };


            for (int i = 0; i < Weddings.Count / 2; i++)
            {
                var test = _context.Couple.Find(i + 1);
                Weddings[i].CoupleId = test.Id;
                Weddings[i].Couple = test;



                await _context.Wedding.AddAsync(Weddings[i]);
            }




            await _context.SaveChangesAsync();



            var FilePathMockNames = @".\MOCK_DATA_14.json";
             var MockNames = JsonConvert.DeserializeObject<List<Guests>>(File.ReadAllText(FilePathMockNames));
            var weddings = _context.Wedding.AsNoTracking().ToList();
            for (int c = 0; c < weddings.Count; c++)
            {
                var bröllop = weddings[c];
            for (int i = 0; i < MockNames.Count; i++)
            {
                MockNames[i].FriendsOrFamily = (FriendsOrFamily)jadu.Next(0, 2);
                MockNames[i].Answer = (Status)jadu.Next(0, 4);
                MockNames[i].Side = (MarrierSide)jadu.Next(0, 3);
                var folktillbröllop = jadu.Next(50, 100);
               
                for (int j = 0; j < folktillbröllop; j++)
                {
                    MockNames[j].JoinedWedding = bröllop;
                }
                
                await _context.AddAsync(MockNames[i]);
            }

            }
            await _context.SaveChangesAsync();

            

        }
    }
}
