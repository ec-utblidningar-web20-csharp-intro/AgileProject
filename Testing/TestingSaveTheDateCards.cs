using System;
using WeddingApi.Utils;
using WeddingApi.Models;
using WeddingApi.Utils.SaveTheDateCard;
using Xunit;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using WeddingApi.Data;

namespace Testing
{
    public class TestingSaveTheDateCards : IClassFixture<WebApplicationFactory<WeddingApi.Startup>>
    {
        private static Random rnd = new Random();
        private const int DaysUntilWedding = 350;
        private const int DaysUntilFinalResponse = 250;

        private readonly WebApplicationFactory<WeddingApi.Startup> _webApplicationFactory;
        public TestingSaveTheDateCards(WebApplicationFactory<WeddingApi.Startup> webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
        }

        [Fact]
        public void ClassConstructed()
        {
            var seedDate = Div.GenerateRandomDate(1950);
            var testCard = new SaveTheDateCardBuilder(GetTestWedding(seedDate));

            GetTestWedding(seedDate);

            Assert.Equal($"Marrier1 and Marrier2 says save the date " +
                $"{seedDate.AddDays(DaysUntilWedding).ToShortDateString()} osv. " +
                $"Respond before {seedDate.AddDays(DaysUntilFinalResponse).ToShortDateString()}. Hadefint",
                testCard.Message);

            new DispatchBuilder(testCard).Deliver();

        }

        [Fact]
        public void ReminderSetUp()
        {
            var seedDate = Div.GenerateRandomDate(1950);
            var testCard = new SaveTheDateCardBuilder(GetTestWedding(seedDate), options =>
            {
                options.SetReminder = true;
            });

            // DI context so we can read if reminder was saved to db
        }


        public Wedding GetTestWedding(DateTime seedDate)
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

            return wedding;

        }
    }
}
