using System;
using WeddingApi.Utils;
using WeddingApi.Models;
using WeddingApi.Utils.SaveTheDateCard;
using Xunit;
using System.Collections.Generic;

namespace Testing
{
    public class Testing_SaveTheDateCards
    {
        private static Random rnd = new Random();
        private const int DaysUntilWedding = 350;
        private const int DaysUntilFinalResponse = 250;

        [Fact]
        public void ClassConstructed()
        {
            var seedDate = Div.GenerateRandomDate(1950);
            var testCard = BuildCard(seedDate);

            Assert.Equal($"Marrier1 and Marrier2 says save the date " +
                $"{seedDate.AddDays(DaysUntilWedding).ToShortDateString()} osv. " +
                $"Respond before {seedDate.AddDays(DaysUntilFinalResponse).ToShortDateString()}. Hadefint",
                testCard.Message);

            new DispatchBuilder(new DeliverOptionsBuilder(), testCard).Deliver();

        }

        public CardBuilder BuildCard(DateTime seedDate)
        {
            var wedding = new Wedding
            {
                RespondBeforeDate = seedDate.AddDays(DaysUntilFinalResponse),
                WeddingDate = seedDate.AddDays(DaysUntilWedding),
                Couple = new WeddingCouple()
                {
                    Merriers = new List<MarrierUser>
                    {
                        new MarrierUser{FirstName = "Marrier1"},
                        new MarrierUser{FirstName = "Marrier2"}
                    }
                }
            };

            var card = new CardBuilder(new CardOptionsBuilder(), wedding);

            return card;

        }
    }
}
