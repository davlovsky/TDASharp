using System;

namespace TDASharp
{
    public static class Conversions
    {
        public static DateTime EpochToMilliseconds(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(unixTime);
        }

        public static string MillisecondsSinceEpoch(DateTime Date)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan span = PreviousWorkDay(Date) - dt1970;
            return Convert.ToInt64(span.TotalMilliseconds).ToString();
        }

        public static DateTime PreviousWorkDay(DateTime date)
        {
            do
            {
                date = date.AddDays(-1);
            }
            while (IsHoliday(date) || IsWeekend(date));

            return date;
        }

        private static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday ||
                   date.DayOfWeek == DayOfWeek.Sunday;
        }

        private static bool IsHoliday(DateTime date)
        {
            return date == new DateTime(DateTime.Now.Year, 01, 01) || // New Years Day
                   date == new DateTime(DateTime.Now.Year, 01, 18) || // MLK
                   date == new DateTime(DateTime.Now.Year, 02, 15) || // Washington's Bday
                   date == new DateTime(DateTime.Now.Year, 04, 02) || // Good Friday
                   date == new DateTime(DateTime.Now.Year, 05, 31) || // Memorial Day
                   date == new DateTime(DateTime.Now.Year, 07, 05) || // Independence Day
                   date == new DateTime(DateTime.Now.Year, 09, 06) || // Labor Day
                   date == new DateTime(DateTime.Now.Year, 11, 25) || // Labor Day
                   date == new DateTime(DateTime.Now.Year, 12, 24);   // Christmas Day
        }
    }
}
