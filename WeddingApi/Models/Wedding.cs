using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WeddingApi.Models
{
    public class Wedding
    {
        public int Id { get; set; }
        public int WeddingCoupleId { get; set; }
        public WeddingCouple Couple { get; set; }

        public DateTime DateOfWedding { get; set; }
        //savethedate-kort? behövs kanske inte.
        public ICollection<Guests> GuestList { get; set; }
        public DateTime GuestsDeadlineForAnswer { get; set; }
    }
}
