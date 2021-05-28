using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingApi.Models.Guests
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

        public MarrierSide Side { get; set; }
        public FriendsOrFamily FriendsOrFamily { get; set; }
        public Kids AmountKids { get; set; }
        public Listtype Answer { get; set; }
        public Allergies Allergies { get; set; }
        public bool PlusOne { get; set; }
        public bool Transport { get; set; }
        public bool Lodging { get; set; }

        public Wedding.Wedding JoinedWedding { get; set; }
    }
    public enum Kids
    {
        None,
        One,
        Two,
        Three,
        Four,
        Five,
        SixOrMore
    }
    public enum FriendsOrFamily
    {
        Friends,
        Family
    }
    public enum Allergies
    {
        Veggie,
        Vegan,
        Lacto,
        Gluten,
        Egg,
        Nuts,
        Shellfish,
        Fruits
    }
    public enum Listtype
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
