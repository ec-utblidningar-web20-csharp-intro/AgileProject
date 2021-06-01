using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Models;

namespace WeddingApi.Data
{
    public class WeddingDbContext : IdentityDbContext<IdentityUser>
    {
        public WeddingDbContext(DbContextOptions<WeddingDbContext> options) : base(options)
        { }
        public DbSet<WeddingCouple> Couples { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
    }
}
