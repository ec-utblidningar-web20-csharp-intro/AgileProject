using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;
        public WeddingRepository(WeddingDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<Wedding> Get(int id, bool asNoTracking = false)
        {
            if (asNoTracking)
            {
                return await _context.Weddings
                    .AsNoTracking()
                    .Where(w => w.CoupleId == id)
                    .FirstOrDefaultAsync();
            }
            return await _context.Weddings
                .Where(w => w.CoupleId == id)
                .FirstOrDefaultAsync();
        }
    }
}
