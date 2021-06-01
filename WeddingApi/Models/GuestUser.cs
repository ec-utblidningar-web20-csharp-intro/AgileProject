using Microsoft.AspNetCore.Identity;

namespace WeddingApi.Models
{
    public class GuestUser : IdentityUser
    {
        public string SocialSecurityNumber { get; set; }
        public string LoginCode { get; set; }
        public Guest Guest { get; set; }
    }
}
