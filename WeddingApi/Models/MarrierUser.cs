using Microsoft.AspNetCore.Identity;

namespace WeddingApi.Models
{
    // If wedding couple don't want/need two accounts
    // Prompt merrierUser to create jointaccount
    public class MarrierUser : IdentityUser
    {
        // Split account props
        public string ConnectUrl { get; set; }
        // name/address/phonenumber/email

        // Joint account props
        public bool IsJointAccount { get; set; }
        public MerrierJointUser MerrierJointUser { get; set; }

        public WeddingCouple WeddingCouple { get; set; }


    }

    public class MerrierJointUser
    {
        public int Id { get; set; }
    }
}
