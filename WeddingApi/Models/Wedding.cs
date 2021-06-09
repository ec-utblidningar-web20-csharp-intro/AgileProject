using System;
using System.Collections.Generic;

namespace WeddingApi.Models
{
    public class Wedding
    {
        public int Id { get; set; }
        public DateTime WeddingDate { get; set; }
        public DateTime RespondBeforeDate { get; set; }
        public int CoupleId { get; set; }
        public WeddingCouple Couple { get; set; }
        public ICollection<Guest> GuestList { get; set; }
        public SaveTheDateCardReminder Reminder { get; set; }
    }
}
