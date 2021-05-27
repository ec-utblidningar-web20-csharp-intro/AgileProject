using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingApi.Models.Guests
{
//Issue10
    public class Guests 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public MarrierSide Side { get; set; }
        public ExtraPpl AmountPpl { get; set; }
        public Listtype Answer { get; set; }
        public Allergies Allergies { get; set; }
        public bool Transport { get; set; }
        public bool Hotel { get; set; }
        public Wedding.Wedding JoinedWedding { get; set; }
        public string LoginCode { get; set; }
    }
    public enum ExtraPpl
    {
        None,
        One,
        Two,
        Three,
        Four,
        Five,
        Six
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
