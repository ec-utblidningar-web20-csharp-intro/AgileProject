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
using static WeddingApi.Models.Enums.GuestOptions;

namespace WeddingApi.Data
{
    public class Seeding
    {
        //private static WeddingDbContext _context { get; set; }
        //private static UserManager<IdentityUser> _userManager { get; set; }

        //public static Random Rnd = new Random();


        //public async static Task Initialize(IServiceProvider services)
        //{
        //    _context = services.GetRequiredService<WeddingDbContext>();
        //    _userManager = services.GetRequiredService<UserManager<IdentityUser>>();

        //    await _context.Database.EnsureDeletedAsync();
        //    await _context.Database.EnsureCreatedAsync();

        //    await ProcessMockData();
        //    await EstablishRelations();
        //}




        //public List<WeddingCouple> couples { get; set; }
        //static async Task ProcessMockData()
        //{
        //    var guestUsersMockDataFilePath = @".\MockDataGuestUsers";
        //    var weddingsMockDataFilePath = @".\MockDataWeddings";

        //    var guestUsers = JsonConvert.DeserializeObject<List<GuestUser>>(File.ReadAllText(guestUsersMockDataFilePath));

        //    foreach (var guestUser in guestUsers)
        //    {
        //        await _userManager.CreateAsync(guestUser, "test123!");
        //    }

        //    // Weddingcouple skall ej ha person/guestuser utan MarrierUser 
        //    // Loop för wedding/weddingcouple kan slås ihop, behöver ej ittereras om 2 gånger
        //    //var weddings = JsonConvert.DeserializeObject<List<Wedding>>(File.ReadAllText(weddingsMockDataFilePath));

        //    //for (int i = 0; i < weddings.Count / 2; i++)
        //    //{
        //    //    WeddingCouple weddingCouple = new WeddingCouple()
        //    //    {
        //    //        Persons = new List<GuestUser>()
        //    //        {
        //    //            guestUsers[i],
        //    //            guestUsers[i + 500]
        //    //        }
        //    //    };

        //    //    await _context.AddAsync(weddingCouple);
        //    //};

        //    //await _context.SaveChangesAsync();

        //    //for (int i = 0; i < weddings.Count / 2; i++)
        //    //{
        //    //    var test = _context.Couples.Find(i + 1);
        //    //    weddings[i].Couple = test;
        //    //    await _context.AddAsync(weddings[i]);
        //    //}

        //    await _context.SaveChangesAsync();

        //    var FilePathMockNames = @".\MOCK_DATA_14.json";
        //    var guests = JsonConvert.DeserializeObject<List<Guest>>(File.ReadAllText(FilePathMockNames));
        //    var weddings = _context.Weddings.AsNoTracking().ToList();
        //    var guestIterator = 0;
        //    for (int c = 0; c < weddings.Count; c++)
        //    {
        //        var invitees = Rnd.Next(50, 100);

        //        for (int j = 0; j < invitees; j++)
        //        {
        //            var guestEntity = guests.Skip(guestIterator).First();
        //            guestEntity.JoinedWedding = weddings[c];
        //            guestEntity.FriendsOrFamily = (FriendsOrFamily)Rnd.Next(0, 2);
        //            guestEntity.Answer = (Status)Rnd.Next(0, 4);
        //            guestEntity.Side = (MarrierSide)Rnd.Next(0, 3);

        //            await _context.AddAsync(guestEntity);

        //            guestIterator = guestIterator >= guests.Count ? 0 : guestIterator++;
        //        }
        //    }
        //    await _context.SaveChangesAsync();


        //    //var folktillbröllop = jadu.Next(50, 100);

        //    //for (int j = 0; j < folktillbröllop; j++)
        //    //{
        //    //    MockNames[j].JoinedWedding = bröllop;
        //    //}



        //}

        //public static async Task EstablishRelations()
        //{

        //}
    }
}
