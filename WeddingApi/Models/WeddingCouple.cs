using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace WeddingApi.Models
{
    public class WeddingCouple
    {
        public int Id { get; set; }
        public ICollection<Person> Persons { get; set; }   
        public Wedding Wedding { get; set; }

    }
}
