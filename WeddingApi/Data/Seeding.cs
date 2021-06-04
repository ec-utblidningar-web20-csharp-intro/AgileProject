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
        private const string MARRIER_USERS_FILE_PATH_MOCK_DATA = @".\Data\MockData\MarrierUser.json";
        private const string GUESTS_FILE_PATH_MOCK_DATA = @".\Data\MockData\Guest.json";
        private const string GUEST_USERS_FILE_PATH_MOCK_DATA = @".\Data\MockData\GuestUser.json";
        private const string WEDDINGS_FILE_PATH_MOCK_DATA = @".\Data\MockData\Wedding.json";

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
        }

        public List<WeddingCouple> couples { get; set; }
        static async Task ProcessMockData()
        {

            var marrierUsers = JsonConvert.DeserializeObject<List<MarrierUser>>(File.ReadAllText(MARRIER_USERS_FILE_PATH_MOCK_DATA));
            var guests = JsonConvert.DeserializeObject<List<Guest>>(File.ReadAllText(GUESTS_FILE_PATH_MOCK_DATA));
            var guestUsers = JsonConvert.DeserializeObject<List<GuestUser>>(File.ReadAllText(GUEST_USERS_FILE_PATH_MOCK_DATA));

            // Add 
            foreach (var marrierUser in marrierUsers)
            {
                await _context.MarrierUser.AddAsync(marrierUser);
                await _userManager.CreateAsync(marrierUser, "Password1!");
            }

            await _context.SaveChangesAsync();



            for (int i = 0; i < marrierUsers.Count / 2; i++)
            {
                WeddingCouple weddingCouple = new WeddingCouple()
                {
                    Merriers = new List<MarrierUser>()
                    {
                        marrierUsers[i],
                        marrierUsers[i + 500]
                    }
                };
                await _context.WeddingCouples.AddAsync(weddingCouple);
            }
            await _context.SaveChangesAsync();

            var Weddings = JsonConvert.DeserializeObject<List<Wedding>>(File.ReadAllText(WEDDINGS_FILE_PATH_MOCK_DATA));

            var guestIterator = 0;

            for (int i = 0; i < 30; i++)
            {
                Weddings[i].Couple = _context.WeddingCouples.Find(i + 1);

                await _context.Weddings.AddAsync(Weddings[i]);
                await _context.SaveChangesAsync();

                var invitees = Rnd.Next(2, 30);

                for (int j = 0; j < invitees; j++)
                {
                    var guestEntity = guests.Skip(guestIterator).First();

                    guestEntity.JoinedWedding = Weddings[i];
                    guestEntity.FriendsOrFamily = (FriendsOrFamily)Rnd.Next(0, 2);
                    guestEntity.Answer = (Status)Rnd.Next(0, 4);
                    guestEntity.Side = (MarrierSide)Rnd.Next(0, 3);

                    if (guestIterator < guests.Count)
                        guestIterator++;
                    else
                        break;

                    await _context.Guests.AddRangeAsync(guestEntity);
                    await _context.SaveChangesAsync();
                }
                if (guestIterator >= guests.Count)
                    break;
            }


            var guestindex = 0;
            foreach (var guestuser in guestUsers)
            {
                guestuser.Guest = guests[guestindex];

                await _context.GuestUsers.AddAsync(guestuser);
                guestindex++;
            }
            await _context.SaveChangesAsync();


        }

    }
}