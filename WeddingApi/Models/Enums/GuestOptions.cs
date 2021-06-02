namespace WeddingApi.Models.Enums
{
    public static class GuestOptions
    {
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
}
