using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingApi.Utils.SaveTheDateCard
{
    public class CardOptionsBuilder
    {
        public bool SetReminder
        {
            get
            {
                return SetReminder;
            }
            set
            {
                ReminderDate = DateTime.Now.AddDays(100);
                SetReminder = value;
            }
        }
        public DateTime ReminderDate { get; set; }
    }
}
