using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingApi.Models.Couple
{
    public class Person : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender{ get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Address { get; set; }
        public WeddingCouple WeddingCouples { get; set; }
        



    }
}
