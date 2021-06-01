using static WeddingApi.Models.Enums.Guest;

namespace WeddingApi.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Allergies { get; set; }
        public int AmountKids { get; set; }

        public MarrierSide Side { get; set; }
        public FriendsOrFamily FriendsOrFamily { get; set; }
        public Status Answer { get; set; }

        public bool HasPlusOne { get; set; }
        public bool NeedTransportation { get; set; }
        public bool NeedLodging { get; set; }

        public Wedding JoinedWedding { get; set; }
        public int GuestUserId { get; set; }
        public GuestUser GuestUser { get; set; }

    }

}
