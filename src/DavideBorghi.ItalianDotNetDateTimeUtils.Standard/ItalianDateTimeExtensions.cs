using DavideBorghi.ItalianDotNetDateTimeUtils.Standard.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DavideBorghi.ItalianDotNetDateTimeUtils.Standard
{
    public static class ItalianDateTimeExtensions
    {
        #region Day

        /// <summary>
        /// Tells if the day of a given date is week end or not.
        /// </summary>
        /// <param name="dateTime">The given date time.</param>
        /// <returns>A boolean value representing if the date of the given date is week end or not.</returns>
        public static bool IsWeekend(this DateTime dateTime)
            => dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;

        #endregion

        #region Week

        /// <summary>
        /// Gets the date of the week start (Monday set as default) of the given date.
        /// </summary>
        /// <param name="dateTime">The given date time.</param>
        /// <param name="startOfWeek">The start day of the week, Monday set as default.</param>
        /// <returns>The date of the week start of the given date.</returns>
        public static DateTime StartOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int num = (7 + (dateTime.DayOfWeek - startOfWeek)) % 7;
            return dateTime.AddDays(-1 * num).Date;
        }

        /// <summary>
        /// Gets the date of the week end (Monday set as default week start day) of the given date.
        /// </summary>
        /// <param name="dateTime">The given date time.</param>
        /// <param name="startOfWeek">The start day of the week, Monday set as default.</param>
        /// <returns>The date of the week end of the given date.</returns>
        public static DateTime EndOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
            => StartOfWeek(dateTime, startOfWeek).AddDays(6.0);

        #endregion

        #region Month

        /// <summary>
        /// Gets an enum representation of the given date month of year.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>An enum representation of the given date month of year.</returns>
        public static MonthOfYear MonthOfYear(this DateTime dateTime)
            => (MonthOfYear)dateTime.Month;

        /// <summary>
        /// Gets the first day of the given date month.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>The date of the first day of the month of the given date.</returns>
        public static DateTime FirstDayOfMonth(this DateTime dateTime)
            => new DateTime(dateTime.Year, dateTime.Month, 1);

        /// <summary>
        /// Gets the last day of the given date month.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>The date of the last day of the month of the given date.</returns>
        public static DateTime LastDayOfMonth(this DateTime dateTime)
            => new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));

        #endregion

        #region Quarter

        /// <summary>
        /// Gets the ordinal number of the date corresponding quarter.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>An integer representing the ordinal number of the date corresponding quarter.</returns>
        public static int Quarter(this DateTime dateTime) => dateTime switch
        {
            _ when (dateTime.Month <= 3) => 1,
            _ when (dateTime.Month <= 6) => 2,
            _ when (dateTime.Month <= 9) => 3,
            _ => 4
        };

        /// <summary>
        /// Gets an enum representing the date corresponding quarter.
        /// </summary>
        /// <param name="dateTime">The givem date.</param>
        /// <returns>An enum representing the ordinal number of the date corresponding quarter.</returns>
        public static QuarterOfYear QuarterOfYear(this DateTime dateTime) => dateTime switch
        {
            _ when (dateTime.Month <= 3) => Enums.QuarterOfYear.First,
            _ when (dateTime.Month <= 6) => Enums.QuarterOfYear.Second,
            _ when (dateTime.Month <= 9) => Enums.QuarterOfYear.Third,
            _ => Enums.QuarterOfYear.Fourth
        };

        //TODO: docs - original name GetFirstDayOfTrimestre
        public static DateTime FirstDayOfQuarter(this DateTime dateTime)
            => new DateTime(dateTime.Year, dateTime.FirstMonthOfQuarter(), 1);

        //TODO: docs - original GetLastDayOfTrimestre
        public static DateTime LastDayOfQuarter(this DateTime dateTime)
            => new DateTime(dateTime.Year, dateTime.LastMonthOfQuarter(), 1).LastDayOfMonth();

        //TODO: docs - original name GetFirstMonthOfTrimestre
        public static int FirstMonthOfQuarter(this DateTime dateTime) => dateTime.Quarter() switch
        {
            1 => 1,
            2 => 4,
            3 => 7,
            _ => 10
        };

        //TODO: docs - original name GetFirstMonthOfTrimestre
        public static MonthOfYear FirstMonthOfQuarterYear(this DateTime dateTime) => dateTime.QuarterOfYear() switch
        {
            Enums.QuarterOfYear.First => Enums.MonthOfYear.January,
            Enums.QuarterOfYear.Second => Enums.MonthOfYear.April,
            Enums.QuarterOfYear.Third => Enums.MonthOfYear.July,
            _ => Enums.MonthOfYear.October
        };

        //TODO: docs - original name GetLastMonthInTrimestre
        public static int LastMonthOfQuarter(this DateTime dateTime) => dateTime.Quarter() switch
        {
            1 => 3,
            2 => 6,
            3 => 9,
            _ => 12
        };

        //TODO: docs - original name GetLastMonthInTrimestre
        public static MonthOfYear LastMonthOfQuarterYear(this DateTime dateTime) => dateTime.QuarterOfYear() switch
        {
            Enums.QuarterOfYear.First => Enums.MonthOfYear.March,
            Enums.QuarterOfYear.Second => Enums.MonthOfYear.June,
            Enums.QuarterOfYear.Third => Enums.MonthOfYear.September,
            _ => Enums.MonthOfYear.December
        };

        #endregion

        #region Four Month Period

        /// <summary>
        /// Gets the ordinal number of the date corresponding fourth month period.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>An integer representing the ordinal number of the date corresponding fourth month period.</returns>
        public static int FourMonthPeriod(this DateTime dateTime) => dateTime switch
        {
            _ when (dateTime.Month <= 4) => 1,
            _ when (dateTime.Month <= 8) => 2,
            _ => 3
        };

        /// <summary>
        /// Gets an enum representing the date corresponding fourth month period.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>An enum representing the ordinal number of the date corresponding fourth month period.</returns>
        public static FourMonthPeriodOfYear FourMonthPeriodOfYear(this DateTime dateTime) => dateTime switch
        {
            _ when (dateTime.Month <= 4) => Enums.FourMonthPeriodOfYear.First,
            _ when (dateTime.Month <= 8) => Enums.FourMonthPeriodOfYear.Second,
            _ => Enums.FourMonthPeriodOfYear.Third
        };

        //TODO: docs - original name GetFirstDayOfQuadrimestre
        public static DateTime FirstDayOfFourMonthPeriod(this DateTime dateTime)
            => new DateTime(dateTime.Year, dateTime.FirstMonthOfFourMonthPeriod(), 1);

        //TODO: docs - original name GetLastDayOfQuadrimestre
        public static DateTime LastDayOfFourMonthPeriod(this DateTime dateTime)
            => new DateTime(dateTime.Year, dateTime.LastMonthOfFourMonthPeriod(), 1).LastDayOfMonth();

        //TODO: docs - original name GetFirstMonthInQuadrimestre
        public static int FirstMonthOfFourMonthPeriod(this DateTime dateTime) => dateTime.FourMonthPeriod() switch
        {
            1 => 1,
            2 => 5,
            _ => 9
        };

        //TODO: docs - original name GetFirstMonthInQuadrimestre
        public static MonthOfYear FirstMonthOfFourMonthPeriodOfYear(this DateTime dateTime) => dateTime.FourMonthPeriodOfYear() switch
        {
            Enums.FourMonthPeriodOfYear.First => Enums.MonthOfYear.January,
            Enums.FourMonthPeriodOfYear.Second => Enums.MonthOfYear.May,
            _ => Enums.MonthOfYear.September
        };

        //TODO: docs - original name GetLastMonthInQuadrimestre
        public static int LastMonthOfFourMonthPeriod(this DateTime dateTime) => dateTime.FourMonthPeriod() switch
        {
            1 => 4,
            2 => 8,
            _ => 12
        };

        //TODO: docs - original name GetLastMonthInQuadrimestre
        public static MonthOfYear LastMonthOfFourMonthPeriodOfYear(this DateTime dateTime) => dateTime.FourMonthPeriodOfYear() switch
        {
            Enums.FourMonthPeriodOfYear.First => Enums.MonthOfYear.April,
            Enums.FourMonthPeriodOfYear.Second => Enums.MonthOfYear.August,
            _ => Enums.MonthOfYear.December
        };

        #endregion
    }
}
