using System;
using System.Collections.Generic;
using System.Linq;

namespace DavideBorghi.ItalianDotNetDateTimeUtils.Standard
{
    public static class ItalianDateTimeUtils
    {
        #region Private Fields

        /// <summary>
        /// Represents an array of strings containing all Italian national holidays, formatted as ddMM 
        /// with the exception of the 17/03/1911, 17/03/1961, 17/03/2011 (Anniversary of the Unification of Italy, which is celebrated every 50 years)
        /// here formatted as 17031911, 17031961 and 17032011
        /// </summary>
        private static readonly string[] _nationalHolidays =
        {
            "0101",
            "0601",
            "2504",
            "0105",
            "0206",
            "1508",
            "0111",
            "0812",
            "2512",
            "2612",
            "17031911",
            "17031961",
            "17032011"
        };

        /// <summary>
        /// Represents a list of DateTime holidays.
        /// </summary>
        private static List<DateTime>? _holidays;

        #endregion

        #region Public Fields

        /// <summary>
        /// Represents a list of local holidays (such as "Saint Patron") that must be in ddMM format.
        /// </summary>
        public static IEnumerable<string>? LocalHolidays;

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the date time from a date formatted as string plus the year as an integer.
        /// </summary>
        /// <param name="dateAsString">Date formatted as ddMM</param>
        /// <param name="year">An integer value representing the year.</param>
        /// <returns>The day in DateTime format.</returns>
        public static DateTime GetDateTimeFromDateAsStringAndYear(string dateAsString, int year)
        {
            int day = int.Parse(dateAsString[..2]);
            int month = int.Parse(dateAsString.Substring(2, 2));
            year = dateAsString.Length > 4 ? int.Parse(dateAsString.Substring(4, 4)) : year;
            return new DateTime(year, month, day);
        }

        /// <summary>
        /// Gets the date time of Easter Sunday given the year.
        /// </summary>
        /// <param name="year">An integer value representing the year.</param>
        /// <returns>The date time representing the Easter Sunday.</returns>
        public static DateTime GetYearlyEaster(int year)
        {
            int num = year % 19;
            int num2 = year / 100;
            int num3 = (num2 - num2 / 4 - (8 * num2 + 13) / 25 + 19 * num + 15) % 30;
            int num4 = num3 - num3 / 28 * (1 - num3 / 28 * (29 / (num3 + 1)) * ((21 - num) / 11));
            int num5 = num4 - (year + year / 4 + num4 + 2 - num2 + num2 / 4) % 7 + 28;
            int num6 = 3;
            if (num5 > 31)
            {
                num6++;
                num5 -= 31;
            }
            return new DateTime(year, num6, num5);
        }

        /// <summary>
        /// Gets an array of years between two dates.
        /// </summary>
        /// <param name="startDate">The starting date.</param>
        /// <param name="endDate">The ending date.</param>
        /// <returns>An array of integers containing the years between the two given dates.</returns>
        /// <exception cref="System.ArgumentException">Thrown when provided starting date is bigger then given ending date.</exception>
        public static int[] GetYearsBetweenDates(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new ArgumentException($"{nameof(startDate)} cannot be bigger than {nameof(endDate)}");

            List<int> years = new List<int>();
            int startYear = startDate.Year;

            while (startYear <= endDate.Year)
                years.Add(startYear++);
            return years.ToArray();
        }

        /// <summary>
        /// Tells if a particular date is an Italian (national or local) holiday or not.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>A boolean value representing whether the given date is an Italian (national or local) holiday or not.</returns>
        public static bool IsHoliday(this DateTime dateTime)
        {
            _holidays = GetYearlyHolidays(dateTime.Year);
            return _holidays.Contains(dateTime) || GetYearlyEaster(dateTime.Year).AddDays(1.0) == dateTime;
        }

        /// <summary>
        /// Gets the number of working days between two given dates, removing weekends and Italian national and local holidays
        /// </summary>
        /// <param name="startDate">The starting date./param>
        /// <param name="endDate">The ending date.</param>
        /// <returns>The number of Italian working days between two dates.</returns>
        /// <exception cref="System.ArgumentException">Thrown when provided starting date is bigger then given ending date.</exception>
        public static int HowManyWorkingDaysBetweenDates(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new ArgumentException($"{nameof(startDate)} cannot be bigger than {nameof(endDate)}");

            int workingDaysCount = 0;
            DateTime currentDateTime = startDate;
            int[] years = GetYearsBetweenDates(startDate, endDate);

            foreach (int year in years)
                GetYearlyHolidays(year);

            while (currentDateTime <= endDate)
            {
                if (!currentDateTime.IsWeekend() && !currentDateTime.IsHoliday())
                    workingDaysCount++;
                currentDateTime = currentDateTime.AddDays(1.0);
            }

            return workingDaysCount;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets a DateTime list of yearly Italian (national or local) holidays.
        /// </summary>
        /// <param name="year">The given year.</param>
        /// <returns>A list of yearly Italian (national or local) holidays.</returns>
        private static List<DateTime> GetYearlyHolidays(int year)
        {
            if (_holidays is null || !_holidays.Any())
                _holidays = new List<DateTime>();
            _nationalHolidays.ToList()
                .ForEach(nh => _holidays.Add(GetDateTimeFromDateAsStringAndYear(nh, year)));
            LocalHolidays?.ToList()
                .ForEach(lh => _holidays.Add(GetDateTimeFromDateAsStringAndYear(lh, year)));
            return _holidays;
        }

        #endregion
    }
}
