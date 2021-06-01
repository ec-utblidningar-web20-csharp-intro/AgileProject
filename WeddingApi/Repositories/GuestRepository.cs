using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WeddingApi.Data;
using WeddingApi.Models;
using static WeddingApi.Models.Enums.Guest;

namespace WeddingApi.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly WeddingDbContext _context;

        public GuestRepository(WeddingDbContext context)
        {
            _context = context;
        }




        public async Task Create(Guest guest)
        {
            await _context.AddAsync(guest);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guest guest)
        {
            _context.Remove(guest);
            await _context.SaveChangesAsync();



        }

        public async Task<IEnumerable<Guest>> Get(Wedding wedding, GuestOptionsBuilder options)
        {
            var guests = _context.Guests.AsNoTracking().AsEnumerable();

            var reflections = options.GetType().GetProperties();
            foreach (var reflection in reflections)
            {
                if (reflection.GetValue(options) != null)
                {
                    guests = guests.Where(g =>
                        (dynamic)typeof(Guest).GetProperty(reflection.Name).GetValue(g) ==
                        (dynamic)reflection.GetValue(options)
                    );
                }

            };
            return guests;
        }

        public Task ResetLoginCode(GuestUser guest)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guest guest)
        {
            throw new NotImplementedException();
        }
    }

    public class GuestOptionsBuilder
    {
        public bool? HasPlusOne { get; set; }
        public bool? NeedTransportation { get; set; }
        public bool? NeedLodging { get; set; }
        public MarrierSide? Side { get; set; }
        public Status? Answer { get; set; }
    }
}
