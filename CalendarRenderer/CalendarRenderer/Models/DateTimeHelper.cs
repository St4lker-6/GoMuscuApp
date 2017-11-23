using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace CalendarRenderer.Models
{
    public static class DateTimeHelper
    {
        public const string monthFormat = "MMMM";
        public const string yearFormat = "yyyy";


        public static Month GetDateInformationsMonthMode(DateTime calendarDateTime)
        {
            CultureInfo currentCultureInfo = CultureInfo.CurrentCulture;

            /// Get the first of the month date time
            var firstOfMonth = new DateTime(calendarDateTime.Year, calendarDateTime.Month, 1);

            var currentMonth = calendarDateTime.Month;

            /// Get the number of day in the month
            var daysInMonth = DateTime.DaysInMonth(calendarDateTime.Year, calendarDateTime.Month);

            /// Retrieve the number of week in the month (partial month)
            var weekInMonth = GetNumberWeekInMonth(firstOfMonth, currentCultureInfo);


            /// The first of the month can not be a monday so we stall on the first monday of the current week 
            var dayBeforeFirstOfWeek = currentCultureInfo.DateTimeFormat.FirstDayOfWeek - firstOfMonth.DayOfWeek;

            if (dayBeforeFirstOfWeek > 0)
            {
                dayBeforeFirstOfWeek = -7 + dayBeforeFirstOfWeek;
            }

            var browsingDate = firstOfMonth.AddDays(dayBeforeFirstOfWeek);

            var Month = new Month(browsingDate.ToString("MMM"));

            /// Browse weeks
            for (int indexDay = 0; indexDay < weekInMonth; indexDay++)
            {
                var week = new Week();

                /// For each day in week
                for (int indexDayInWeek = 0; indexDayInWeek < 7; indexDayInWeek++)
                {
                    if (browsingDate.Month == currentMonth)
                    {
                        week.Days.Add(new Day { NumberDay = browsingDate.Day, NameDay = browsingDate.ToString("ddd"), Valid = true });
                        browsingDate = browsingDate.AddDays(1);
                    }
                    else
                    {
                        week.Days.Add(new Day { Valid = false });
                        browsingDate = browsingDate.AddDays(1);
                    }
                }

                Month.Weeks.Add(week);
            }

            return Month;
        }

        /// <summary>
        /// Allows to calculate the number of week in the month including the partial week
        /// </summary>
        /// <param name = "firstOfMonth" ></ param >
        /// < returns ></ returns >
        private static int GetNumberWeekInMonth(DateTime firstOfMonth, CultureInfo cultureInfo)
        {
            var monthBegin = firstOfMonth.Month;
            var yearBegin = firstOfMonth.Year;
            int numberWeek = 0;
            DateTime browsingDate = firstOfMonth;
            
            /// Be carreful if the current mont is december, the next month is inferior but not the year
            while (browsingDate.Month <= monthBegin && browsingDate.Year <= yearBegin)
            {
                numberWeek++;

                /// Next week
                browsingDate = browsingDate.AddDays(7);

                /// Stalling on the first day of week to include all the week even the partial week
                var dayBeforeFirstOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek - browsingDate.DayOfWeek;
                if (dayBeforeFirstOfWeek != 0)
                {
                    /// The new browsing date is now fixed with the first day of the week
                    browsingDate = browsingDate.AddDays(dayBeforeFirstOfWeek);
                }
            }

            return numberWeek;
        }

        public static ObservableCollection<Year> GetDateInformationsYearMode(DateTime calendarDateTime)
        {
            CultureInfo currentCultureInfo = CultureInfo.CurrentCulture;

            var years = new ObservableCollection<Year>();
            var year = new Year();

            var browsingMonth = new DateTime(calendarDateTime.Year, 1, 1);

            for (int indexLineMonth = 0; indexLineMonth < 3; indexLineMonth++)
            {
                for (int indexColumnMoth = 0; indexColumnMoth < 4; indexColumnMoth++)
                {
                    var month = new Month(browsingMonth.ToString("MMM"));
                    year.Months.Add(month);

                    browsingMonth = browsingMonth.AddMonths(1);
                }
            }

            years.Add(year);

            return years;
        }
    }
}
