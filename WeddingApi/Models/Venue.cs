using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Models;

namespace WeddingApi.Models
{
    public class Venue : Entity
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string ContactName { get; set; }
        public bool IsAccessible { get; set; }
        // prop for tables 
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Wedding> Weddings { get; set; }

    }
}
