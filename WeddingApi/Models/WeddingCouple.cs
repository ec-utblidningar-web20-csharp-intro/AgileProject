using System.Collections.Generic;
namespace WeddingApi.Models
{
    public class WeddingCouple : Entity
    {
        public Wedding Wedding { get; set; }
        public ICollection<MarrierUser> Merriers { get; set; }

    }
}
