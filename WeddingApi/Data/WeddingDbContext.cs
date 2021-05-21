using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Model.Couple;

namespace WeddingApi.Data
{
    public class WeddingDbContext : IdentityDbContext
    {
        public DbSet<WeddingCouple> Couple { get; set; }
    }
}
