using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Data;
using WeddingApi.Models;

namespace WeddingApi.Repositories
{
    public class WeddingRepository : IWeddingRepository
    {
        private readonly WeddingDbContext _context;
        public WeddingRepository(WeddingDbContext context)
        {
            _context = context;
        }
        public async Task<Wedding> Get(int id, bool asNoTracking = false)
        {
            if (asNoTracking)
            {
                return await _context.Weddings
                    .AsNoTracking()
                    .Where(w => w.GuestList.Contains(_context.Guests.Find(id)))
                    .FirstOrDefaultAsync();
            }
            return await _context.Weddings
                .Where(w => w.GuestList == 
                _context.Guests
                .Where(g => g.Id == id))
                .FirstOrDefaultAsync();
        }
    }
}
