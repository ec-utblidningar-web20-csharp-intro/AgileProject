using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingApi.Utils
{
    public static class Div
    {
        public static Random rnd = new Random();
        public static DateTime GenerateRandomDate(int startYear = 2000, int startMonth = 1, int startDay = 1,
            DateTimeKind dateTimeKind = DateTimeKind.Utc)
        {
            var startDate = new DateTime(startYear, startMonth, startDay, 1, 1, 1, dateTimeKind);
            var timeRange = DateTime.Today - startDate;

            return startDate.AddDays(rnd.Next(timeRange.Days));
        }
    }
}
