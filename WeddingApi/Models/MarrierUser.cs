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
        public string SecondUserFirstName { get; set; }
        public string SecondUserLastName { get; set; }
        public string SecondUserEmail { get; set; }
        public string SecondUserPhoneNumber { get; set; }


        // Global props
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public WeddingCouple WeddingCouple { get; set; }

    }

}
