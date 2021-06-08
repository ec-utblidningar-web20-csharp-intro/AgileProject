using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Models;

namespace WeddingApi.Utils.SaveTheDateCard
{
    public class CardBuilder
    {
        public const string MessageTemplate = "{0} and {1} says save the date {2} osv. Respond before {3}. Hadefint";
        public string Message { get; private set; }
        public CardOptionsBuilder Options { get; private set; }
        public Wedding Wedding { get; private set; }
        public IEnumerable<string> Emails { get; private set; }

        public CardBuilder(Wedding wedding, Action<CardOptionsBuilder> optionsAction = null)
        {
            Options = new CardOptionsBuilder();
            optionsAction?.Invoke(Options);
            Wedding = wedding;
            GenerateMessage();
            CollectEmails();
        }

        private void GenerateMessage()
        {
            Message = String.Format(MessageTemplate,
                Wedding.Couple.Merriers.First().FirstName,
                Wedding.Couple.Merriers.Last().FirstName,
                Wedding.WeddingDate.ToShortDateString(),
                Wedding.RespondBeforeDate.ToShortDateString());
        }

        public void CollectEmails()
        {
            var guestList = Wedding.GuestList;
            if (guestList != null)
            {
                Emails = Wedding.GuestList
                    .Select(g => g.GuestUser.Email);
            }
        }
    }
}
