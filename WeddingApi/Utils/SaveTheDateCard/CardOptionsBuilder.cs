using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingApi.Utils.SaveTheDateCard
{
    public class CardOptionsBuilder
    {
        private bool hasReminder;
        public bool HasReminder
        {
            get { return hasReminder; }
            set
            {
                ReminderDate = DateTime.Now.AddDays(100);
                hasReminder = value;
            }
        }
        public bool SendByEmail { get; set; }
        public bool SendByText { get; set; }
        public bool SendByRunner { get; set; }
        public DateTime ReminderDate { get; set; }
    }
}
