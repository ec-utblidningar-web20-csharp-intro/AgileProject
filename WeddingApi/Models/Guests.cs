using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingApi.Models
{

    public class Guests 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string LoginCode { get; set; }
        public string Allergies { get; set; }
        public int AmountKids { get; set; }

        public MarrierSide Side { get; set; }
        public FriendsOrFamily FriendsOrFamily { get; set; }
        public Status Answer { get; set; }

        

        public bool HasPlusOne { get; set; }
        public bool NeedTransportation { get; set; }
        public bool NeedLodging { get; set; }

        public Wedding JoinedWedding { get; set; }
    }

    public enum FriendsOrFamily
    {
        Friends,
        Family
    }
    public enum Status
    {
        AcceptedList,
        PossibleList,
        PendingList,
        DeclinedList,
    }
    public enum MarrierSide
    {
        MarrierA,
        MarrierB,
        Both
    }
}
