using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingApi.Models
{
    public class SaveTheDateCardReminder : Entity
    {
        public DateTime Date { get; set; }
        public bool ShouldRepeat { get; set; }
        public int WeddingId { get; set; }
        public Wedding Wedding { get; set; }
    }
}
