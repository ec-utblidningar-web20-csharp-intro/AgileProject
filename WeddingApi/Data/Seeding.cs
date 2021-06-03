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

        static async Task ProcessMockData()
        {

            var marrierUsers = JsonConvert.DeserializeObject<List<MarrierUser>>(File.ReadAllText(MARRIER_USERS_FILE_PATH_MOCK_DATA));
            var guests = JsonConvert.DeserializeObject<List<Guest>>(File.ReadAllText(GUESTS_FILE_PATH_MOCK_DATA));
            //var guestUsers = JsonConvert.DeserializeObject<List<GuestUser>>(File.ReadAllText(GUEST_USERS_FILE_PATH_MOCK_DATA));
            var weddings = JsonConvert.DeserializeObject<List<Wedding>>(File.ReadAllText(WEDDINGS_FILE_PATH_MOCK_DATA));

            for (int i = 0; i < marrierUsers.Count; i++)
            {
                await _context.MarrierUser.AddAsync(marrierUsers[i]);
                await _userManager.CreateAsync(marrierUsers[i], "Password1!");
                if (i % 2 != 0)
                {
                    await _context.AddAsync(new WeddingCouple
                    {
                        Merriers = new List<MarrierUser>
                        {
                            marrierUsers[i],
                            marrierUsers[i-1]
                        },
                        Wedding = weddings[i / 2]
                    });
                }
            }
            //await _context.SaveChangesAsync();

            var guestIterator = 0;
            for (int i = 0; i < weddings.Count; i++)
            {
                var wedding = await _context.AddAsync(weddings[i]);

                var invitees = Rnd.Next(2, 30);
                for (int j = 0; j < invitees; j++)
                {
                    var guest = guests.Skip(guestIterator).First();
                    guest.JoinedWedding = weddings[i];
                    guest.FriendsOrFamily = (FriendsOrFamily)Rnd.Next(0, 2);
                    guest.Answer = (Status)Rnd.Next(0, 4);
                    guest.Side = (MarrierSide)Rnd.Next(0, 3);

                    await _context.AddAsync(guest);

                    weddings[i].GuestList.Add(guest);

                    var guestUser = new GuestUser
                    {
                        LoginCode = new Guid().ToString(),
                        Guest = guest
                    };
                    await _context.AddAsync(guestUser);
                    await _userManager.CreateAsync(guestUser, "Password1!");

                    guestIterator = guestIterator == guests.Count - 1 ? 0 : guestIterator + 1;
                }
            }
            await _context.SaveChangesAsync();


        }


    }
}