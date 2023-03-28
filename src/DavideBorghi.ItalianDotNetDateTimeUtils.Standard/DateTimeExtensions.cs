﻿using DavideBorghi.ItalianDotNetDateTimeUtils.Standard.DateTimeEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DavideBorghi.ItalianDotNetDateTimeUtils.Standard
{
    public static class DateTimeExtensions
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
        /// <param name="dateTime">The given date.</param>
        /// <returns>An enum representing the quarter related to the given date.</returns>
        public static QuarterOfYear QuarterOfYear(this DateTime dateTime) => dateTime switch
        {
            _ when (dateTime.Month <= 3) => DateTimeEnums.QuarterOfYear.First,
            _ when (dateTime.Month <= 6) => DateTimeEnums.QuarterOfYear.Second,
            _ when (dateTime.Month <= 9) => DateTimeEnums.QuarterOfYear.Third,
            _ => DateTimeEnums.QuarterOfYear.Fourth
        };

        /// <summary>
        /// Gets the first day of the date corresponding quarter.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>A date time representing the first day of the date corresponding quarter.</returns>
        public static DateTime FirstDayOfQuarter(this DateTime dateTime)
            => new DateTime(dateTime.Year, dateTime.FirstMonthOfQuarter(), 1);

        /// <summary>
        /// Gets the last day of the date corresponding quarter.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>A date time representing the last day of the date corresponding quarter.</returns>
        public static DateTime LastDayOfQuarter(this DateTime dateTime)
            => new DateTime(dateTime.Year, dateTime.LastMonthOfQuarter(), 1).LastDayOfMonth();

        /// <summary>
        /// Gets the ordinal number of the first month of the date corresponding quarter.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>An integer representing the ordinal number of the first month of the date corresponding quarter.</returns>
        public static int FirstMonthOfQuarter(this DateTime dateTime) => dateTime.Quarter() switch
        {
            1 => 1,
            2 => 4,
            3 => 7,
            _ => 10
        };

        /// <summary>
        /// Gets an enum representing the first month of the date corresponding quarter.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>An enum representing the first month of the date corresponding quarter.</returns>
        public static MonthOfYear FirstMonthOfQuarterYear(this DateTime dateTime) => dateTime.QuarterOfYear() switch
        {
            DateTimeEnums.QuarterOfYear.First => DateTimeEnums.MonthOfYear.January,
            DateTimeEnums.QuarterOfYear.Second => DateTimeEnums.MonthOfYear.April,
            DateTimeEnums.QuarterOfYear.Third => DateTimeEnums.MonthOfYear.July,
            _ => DateTimeEnums.MonthOfYear.October
        };


        /// <summary>
        /// Gets the ordinal number of the last month of the date corresponding quarter.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>An integer representing the ordinal number of the last month of the date corresponding quarter.</returns>
        public static int LastMonthOfQuarter(this DateTime dateTime) => dateTime.Quarter() switch
        {
            1 => 3,
            2 => 6,
            3 => 9,
            _ => 12
        };

        /// <summary>
        /// Gets an enum representing the last month of the date corresponding quarter.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>An enum representing the last month of the date corresponding quarter.</returns>
        public static MonthOfYear LastMonthOfQuarterYear(this DateTime dateTime) => dateTime.QuarterOfYear() switch
        {
            DateTimeEnums.QuarterOfYear.First => DateTimeEnums.MonthOfYear.March,
            DateTimeEnums.QuarterOfYear.Second => DateTimeEnums.MonthOfYear.June,
            DateTimeEnums.QuarterOfYear.Third => DateTimeEnums.MonthOfYear.September,
            _ => DateTimeEnums.MonthOfYear.December
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
            _ when (dateTime.Month <= 4) => DateTimeEnums.FourMonthPeriodOfYear.First,
            _ when (dateTime.Month <= 8) => DateTimeEnums.FourMonthPeriodOfYear.Second,
            _ => DateTimeEnums.FourMonthPeriodOfYear.Third
        };

        /// <summary>
        /// Gets the first day of the date corresponding four mounth period.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>A date time representing the first day of the date corresponding four month period.</returns>
        public static DateTime FirstDayOfFourMonthPeriod(this DateTime dateTime)
            => new DateTime(dateTime.Year, dateTime.FirstMonthOfFourMonthPeriod(), 1);

        /// <summary>
        /// Gets the last day of the date corresponding four mounth period.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>A date time representing the last day of the date corresponding four month period.</returns>
        public static DateTime LastDayOfFourMonthPeriod(this DateTime dateTime)
            => new DateTime(dateTime.Year, dateTime.LastMonthOfFourMonthPeriod(), 1).LastDayOfMonth();

        /// <summary>
        /// Gets the ordinal number of the first month of the date corresponding four month period.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>An integer representing the ordinal number of the first month of the date corresponding four month period.</returns>
        public static int FirstMonthOfFourMonthPeriod(this DateTime dateTime) => dateTime.FourMonthPeriod() switch
        {
            1 => 1,
            2 => 5,
            _ => 9
        };

        /// <summary>
        /// Gets an enum representing the first month of the date corresponding four month period.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>An enum representing the first month of the date corresponding four month period.</returns>
        public static MonthOfYear FirstMonthOfFourMonthPeriodOfYear(this DateTime dateTime) => dateTime.FourMonthPeriodOfYear() switch
        {
            DateTimeEnums.FourMonthPeriodOfYear.First => DateTimeEnums.MonthOfYear.January,
            DateTimeEnums.FourMonthPeriodOfYear.Second => DateTimeEnums.MonthOfYear.May,
            _ => DateTimeEnums.MonthOfYear.September
        };

        /// <summary>
        /// Gets the ordinal number of the last month of the date corresponding four month period.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>An integer representing the ordinal number of the last month of the date corresponding four month period.</returns>
        public static int LastMonthOfFourMonthPeriod(this DateTime dateTime) => dateTime.FourMonthPeriod() switch
        {
            1 => 4,
            2 => 8,
            _ => 12
        };

        /// <summary>
        /// Gets an enum representing the last month of the date corresponding four month period.
        /// </summary>
        /// <param name="dateTime">The given date.</param>
        /// <returns>An enum representing the last month of the date corresponding four month period.</returns>
        public static MonthOfYear LastMonthOfFourMonthPeriodOfYear(this DateTime dateTime) => dateTime.FourMonthPeriodOfYear() switch
        {
            DateTimeEnums.FourMonthPeriodOfYear.First => DateTimeEnums.MonthOfYear.April,
            DateTimeEnums.FourMonthPeriodOfYear.Second => DateTimeEnums.MonthOfYear.August,
            _ => DateTimeEnums.MonthOfYear.December
        };

        #endregion
    }
}
