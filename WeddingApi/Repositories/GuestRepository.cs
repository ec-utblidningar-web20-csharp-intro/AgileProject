using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Data;
using WeddingApi.Models;
using WeddingApi.Models.Enums;

namespace WeddingApi.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly WeddingDbContext _context;

        public GuestRepository(WeddingDbContext context)
        {
            _context = context;
        }

        // Get guest by id -> bool param for no tracking option
        public async Task<Guest> Get(int id, bool asNoTracking = false)
        {
            if (asNoTracking)
            {
                return await _context.Guests
                    .AsNoTracking()
                    .FirstOrDefaultAsync(g => g.Id == id);
            }
            return await _context.Guests
                .FindAsync(id);
        }

        // Get collection of guests, param guestoptionsbuilder for sorting
        public IEnumerable<Guest> Get(Wedding wedding, GuestOptionsBuilder options)
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

        // Save guest 
        public async Task Create(Guest guest)
        {
            await _context.AddAsync(guest);
            await _context.SaveChangesAsync();
        }

        // Save collections of guests 
        public async Task Create(IEnumerable<Guest> guests)
        {
            await _context.AddRangeAsync(guests);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guest guest)
        {
            _context.Remove(guest);
            await _context.SaveChangesAsync();
        }

        // Reset code from guest
        // Create utils namespace and and method for generating our codes
        public async Task ResetLoginCode(Guest guest)
        {
            var guestUser = await _context.GuestUsers
                .FirstOrDefaultAsync(g => g.Guest == guest);
            var newCode = "";
            // newCode = GenerateNewGuestLoginCode();
            guestUser.LoginCode = newCode;
        }

        // Reset code from guestuser
        public Task ResetLoginCode(GuestUser guest)
        {
            var newCode = "";
            // newCode = GenerateNewGuestLoginCode();
            guest.LoginCode = newCode;
            throw new NotImplementedException();
        }

        public async Task Update(Guest guest)
        {
            _context.Update(guest);
            await _context.SaveChangesAsync();
        }
    }

    public class GuestOptionsBuilder
    {
        public bool? HasPlusOne { get; set; }
        public bool? NeedTransportation { get; set; }
        public bool? NeedLodging { get; set; }
        public GuestOptions.MarrierSide? Side { get; set; }
        public GuestOptions.Status? Answer { get; set; }
    }
}
