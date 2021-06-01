using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Models.Couple;
using WeddingApi.Models.GuestTableImg;
using WeddingApi.Models.Wedding;

namespace WeddingApi.Data
{
    public class TestSeed
    {
        private static WeddingDbContext _context { get; set; }
        private static UserManager<IdentityUser> _userManager { get; set; }
        

        public async static Task Seeder(IServiceProvider services)
        {
            _context = services.GetRequiredService<WeddingDbContext>();
            _userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            

            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();

            await TestSeedWedding();
            
        }
        static async Task TestSeedWedding()
        {
            Person person1 = new Person()
            {
                FirstName = "Test1",
                LastName = "Test1",
                UserName = "Test",
                Address = "TestAddress",
                Email = "test@test.com",
                Gender = "male",
                SocialSecurityNumber = "842929389",
            };
            await _userManager.CreateAsync(person1, "test123!");
            Person person2 = new Person()
            {
                FirstName = "Test2",
                LastName = "Test2",
                UserName = "Test",
                Address = "TestAddress",
                Email = "test@test.com",
                Gender = "female",
                SocialSecurityNumber = "842929389",
            };
            
            WeddingCouple weddingCouple = new WeddingCouple()
            {
                Persons = new List<Person>()
                {
                    person1,
                    person2
                }
                
            };
            await _userManager.CreateAsync(person2, "test123!");
            Wedding wedding = new Wedding()
            {
                Couple = weddingCouple,
                 
            };

            var guestTables = new GuestTable[]
           {
                new GuestTable{TableName = "Table-A", URLImage ="~/img/Guest_Table/01.jpg"},
                new GuestTable{TableName = "Table-B", URLImage ="~/img/Guest_Table/02.jpg"},
                new GuestTable{TableName = "Table-A", URLImage ="~/img/Guest_Table/03.jpg"},
                new GuestTable{TableName = "Table-B", URLImage ="~/img/Guest_Table/04.jpg"},
                new GuestTable{TableName = "Table-A", URLImage ="~/img/Guest_Table/05.jpg"},
                new GuestTable{TableName = "Table-B", URLImage ="~/img/Guest_Table/06.jpg"},
                new GuestTable{TableName = "Table-A", URLImage ="~/img/Guest_Table/07.jpg"},
                new GuestTable{TableName = "Table-B", URLImage ="~/img/Guest_Table/08.jpg"},
               
           };

            foreach (GuestTable t in guestTables)
            {
                await _context.AddAsync(t);
            }

            await _context.AddAsync(weddingCouple);
            await _context.AddAsync(wedding);
            await _context.SaveChangesAsync();

        }

       
    }
}
