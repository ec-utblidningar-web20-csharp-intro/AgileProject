using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingApi.Models
{
    public class Review : Entity
    {
        public Venue Venue { get; set; }
    }
}
