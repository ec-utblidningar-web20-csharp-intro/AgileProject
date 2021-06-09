using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeddingApi.Models;

namespace WeddingApi.Data
{
    public class WeddingDbContext : IdentityDbContext<IdentityUser>
    {
        public WeddingDbContext(DbContextOptions<WeddingDbContext> options) : base(options)
        { }

        public DbSet<WeddingCouple> WeddingCouples { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<GuestUser> GuestUsers { get; set; }
        public DbSet<MarrierUser> MarrierUser { get; set; }
        public DbSet<SaveTheDateCardReminder> SaveTheDateCardReminders { get; set; }

    }
}
