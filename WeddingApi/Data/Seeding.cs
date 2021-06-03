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
        private static WeddingDbContext _context { get; set; }
        private static UserManager<IdentityUser> _userManager { get; set; }

        public static Random Rnd = new Random();


        public async static Task Initialize(IServiceProvider services)
        {
            _context = services.GetRequiredService<WeddingDbContext>();
            _userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();

            await ProcessMockData();
            await EstablishRelations();
        }




        public List<WeddingCouple> couples { get; set; }
        static async Task ProcessMockData()
        {
            var FilePathMarrierUser = @".\MarrierUser.json";
            var MarrierUsers = JsonConvert.DeserializeObject<List<MarrierUser>>(File.ReadAllText(FilePathMarrierUser));

            foreach (var marrieruser in MarrierUsers)
                await _context.MerrierUser.AddAsync(marrieruser);

            await _context.SaveChangesAsync();

            var FilePathGuest = @".\Guest.json";
            var Guests = JsonConvert.DeserializeObject<List<Guest>>(File.ReadAllText(FilePathGuest));



            var FilePathGuestUser = @".\GuestUser.json";
            var GuestUsers = JsonConvert.DeserializeObject<List<GuestUser>>(File.ReadAllText(FilePathGuestUser));




            for (int i = 0; i < MarrierUsers.Count / 2; i++)
            {
                WeddingCouple weddingCouple = new WeddingCouple()
                {
                    Merriers = new List<MarrierUser>()
                    {
                        MarrierUsers[i],
                        MarrierUsers[i + 500]
                    }
                };
                await _context.WeddingCouples.AddAsync(weddingCouple);
            }
            await _context.SaveChangesAsync();

            var FilePathWedding = @".\Wedding.json";
            var Weddings = JsonConvert.DeserializeObject<List<Wedding>>(File.ReadAllText(FilePathWedding));

            var guestIterator = 0;

            for (int i = 0; i < 30; i++)
            {
                Weddings[i].Couple = _context.WeddingCouples.Find(i + 1);

                await _context.Weddings.AddAsync(Weddings[i]);
                await _context.SaveChangesAsync();

                var invitees = Rnd.Next(2, 30);

                for (int j = 0; j < invitees; j++)
                {
                    var guestEntity = Guests.Skip(guestIterator).First();

                    guestEntity.JoinedWedding = Weddings[i];
                    guestEntity.FriendsOrFamily = (FriendsOrFamily)Rnd.Next(0, 2);
                    guestEntity.Answer = (Status)Rnd.Next(0, 4);
                    guestEntity.Side = (MarrierSide)Rnd.Next(0, 3);

                    if (guestIterator < Guests.Count)
                        guestIterator++;
                    else
                        break;

                    await _context.Guests.AddRangeAsync(guestEntity);
                    await _context.SaveChangesAsync();
                }
                if (guestIterator >= Guests.Count)
                    break;
            }


            var guestindex = 0;
            foreach (var guestuser in GuestUsers)
            {
                guestuser.Guest = Guests[guestindex];

                await _context.GuestUsers.AddAsync(guestuser);
                guestindex++;
            }
            await _context.SaveChangesAsync();


        }

        public static async Task EstablishRelations()
        {

        }
    }
}