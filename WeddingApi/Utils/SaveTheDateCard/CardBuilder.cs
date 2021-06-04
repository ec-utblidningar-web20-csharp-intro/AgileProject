using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Models;

namespace WeddingApi.Utils.SaveTheDateCard
{
    public class CardBuilder
    {
        private readonly CardOptionsBuilder _options;
        private readonly Models.Wedding _wedding;

        public const string MessageTemplate = "{0} and {1} says save the date {2} osv. Respond before {3}. Hadefint";

        public string Message { get; private set; }
        public IEnumerable<string> Emails { get; private set; }

        public CardBuilder(CardOptionsBuilder options, Models.Wedding wedding)
        {
            _options = options;
            _wedding = wedding;
            GenerateMessage();
            CollectEmails();
        }

        private void GenerateMessage()
        {
            Message = String.Format(MessageTemplate,
                _wedding.Couple.Merriers.First().FirstName,
                _wedding.Couple.Merriers.Last().FirstName,
                _wedding.WeddingDate.ToShortDateString(),
                _wedding.RespondBeforeDate.ToShortDateString());
        }

        public void CollectEmails()
        {
            Emails = _wedding.GuestList
                .Select(g => g.GuestUser.Email);
        }
    }
}
