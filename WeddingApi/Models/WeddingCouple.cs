using System.Collections.Generic;
namespace WeddingApi.Models
{
    public class WeddingCouple
    {
        public int Id { get; set; }
        public Wedding Wedding { get; set; }
        public ICollection<MarrierUser> Merriers { get; set; }

    }
}
