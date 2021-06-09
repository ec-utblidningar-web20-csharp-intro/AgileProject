using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Models;

namespace WeddingApi.Utils.SaveTheDateCard
{
    public class SaveTheDateCardBuilder
    {
        public const string MessageTemplate = "{0} and {1} says save the date {2} osv. Respond before {3}. Hadefint";
        public string Message { get; private set; }
        public CardOptionsBuilder Options { get; set; }
        public Wedding Wedding { get; private set; }

        public SaveTheDateCardBuilder(Wedding wedding, Action<CardOptionsBuilder> optionsAction = null)
        {
            Options = new CardOptionsBuilder();
            optionsAction?.Invoke(Options);
            Wedding = wedding;
            GenerateMessage();
        }

        private void GenerateMessage()
        {
            Message = String.Format(MessageTemplate,
                Wedding.Couple.Merriers.First().FirstName,
                Wedding.Couple.Merriers.Last().FirstName,
                Wedding.WeddingDate.ToShortDateString(),
                Wedding.RespondBeforeDate.ToShortDateString());
        }

    }
}
