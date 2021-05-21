using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace WeddingApi.Models.Couple
{
    public class WeddingCouple
    {
        public int Id { get; set; }
        public ICollection<Person> Persons { get; set; }   
        public Models.Wedding.Wedding Wedding { get; set; }

    }
}
