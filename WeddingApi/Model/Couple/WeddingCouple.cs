using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingApi.Model.Couple
{
    public class WeddingCouple 
    {
        public Person PersonOne { get; set; }
        public Person PersonTwo { get; set; }
        public string Address { get; set; }
    }
}
