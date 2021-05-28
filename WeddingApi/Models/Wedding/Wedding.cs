using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Models.Couple;

namespace WeddingApi.Models.Wedding
{
    public class Wedding
    {
        public int Id { get; set; }
        public int WeddingCoupleId { get; set; }
        public WeddingCouple Couple { get; set; }

        public DateTime DateOfWedding { get; set; }
        public string Address { get; set; }


        //savethedate-kort? behövs kanske inte.
        public Guests.Guests GuestList { get; set; }
        public DateTime GuestsDeadlineForAnswer { get; set; }
    }
}
