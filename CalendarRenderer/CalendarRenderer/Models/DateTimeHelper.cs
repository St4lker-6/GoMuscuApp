using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace CalendarRenderer.Models
{
    public static class DateTimeHelper
    {
        public static ObservableCollection<Week> GetDateInformations(DateTime calendarDateTime)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;

            /// Get the first of the month date time
            //var dateBeginMonth = calendarDateTime.AddDays(1 - calendarDateTime.Date.Day);
            var firstOfMonth = new DateTime(calendarDateTime.Year, calendarDateTime.Month, 1);

            var currentMonth = calendarDateTime.Month;

            /// Get the number of day in the month
            var daysInMonth = DateTime.DaysInMonth(calendarDateTime.Year, calendarDateTime.Month);

            /// Retrieve the number of week in the month (partial month)
            var weekInMonth = GetNumberWeekInMonth(firstOfMonth, cultureInfo);

            var Weeks = new ObservableCollection<Week>();

            /// The first of the month can not be a monday so we stall on the first monday of the current week 
            var dayBeforeFirstOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek - firstOfMonth.DayOfWeek;

            if (dayBeforeFirstOfWeek > 0)
            {
                dayBeforeFirstOfWeek = -7 + dayBeforeFirstOfWeek;
            }

            var dateFirstMondayBeginMonth = firstOfMonth.AddDays(dayBeforeFirstOfWeek);

            /// Browse weeks
            for (int indexDay = 0; indexDay < weekInMonth; indexDay++)
            {
                var week = new Week();

                /// For each day in week
                for (int indexDayInWeek = 0; indexDayInWeek < 7; indexDayInWeek++)
                {
                    if (dateFirstMondayBeginMonth.Month == currentMonth)
                    {
                        week.Days.Add(new Day { NumberDay = dateFirstMondayBeginMonth.Day, NameDay = dateFirstMondayBeginMonth.ToString("ddd"), Valid = true });
                        dateFirstMondayBeginMonth = dateFirstMondayBeginMonth.AddDays(1);
                    }
                    else
                    {
                        week.Days.Add(new Day { Valid = false });
                        dateFirstMondayBeginMonth = dateFirstMondayBeginMonth.AddDays(1);
                    }
                }

                Weeks.Add(week);
            }

            return Weeks;

        }

        /// <summary>
        /// Allows to calculate the number of week in the month including the partial week
        /// </summary>
        /// <param name = "firstOfMonth" ></ param >
        /// < returns ></ returns >
        private static int GetNumberWeekInMonth(DateTime firstOfMonth, CultureInfo cultureInfo)
        {
            var monthBegin = firstOfMonth.Month;
            int numberWeek = 0;
            DateTime browsingMonthDate = firstOfMonth;

            while (browsingMonthDate.Month <= monthBegin)
            {
                numberWeek++;

                /// Next week
                browsingMonthDate = browsingMonthDate.AddDays(7);

                /// Stalling on the first day of week to include the last partial week
                var dayBeforeFirstOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek - browsingMonthDate.DayOfWeek;

                if (dayBeforeFirstOfWeek > 0)
                {
                    /// So if the first of the week is still in the month we incremente the number of week one last time
                    browsingMonthDate.AddDays(dayBeforeFirstOfWeek);
                }
            }



            return numberWeek;
        }
    }
}
