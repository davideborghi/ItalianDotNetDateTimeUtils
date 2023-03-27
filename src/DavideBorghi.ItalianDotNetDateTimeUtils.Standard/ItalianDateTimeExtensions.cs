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
        /// <returns>Returns the date of the week start of the given date.</returns>
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
        /// <returns>Returns the date of the week end of the given date.</returns>
        public static DateTime EndOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
            => StartOfWeek(dateTime, startOfWeek).AddDays(6.0);

        #endregion

        #region Month

        //TODO: docs - original name GetLastDayOfMonth
        public static DateTime LastDayOfMonth(this DateTime dateTime)
            => new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));

        //TODO: docs - original name GetFirstDayOfMonth
        public static DateTime FirstDayOfMonth(this DateTime dateTime)
            => new DateTime(dateTime.Year, dateTime.Month, 1);

        #endregion

        #region Quarter

        //TODO: docs - original name GetTrimestre
        public static int Quarter(this DateTime dateTime) => dateTime switch
        {
            _ when (dateTime.Month <= 3) => 1,
            _ when (dateTime.Month <= 6) => 2,
            _ when (dateTime.Month <= 9) => 3,
            _ => 4
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

        //TODO: docs - original name GetLastMonthInTrimestre
        public static int LastMonthOfQuarter(this DateTime dateTime) => dateTime.Quarter() switch
        {
            1 => 3,
            2 => 6,
            3 => 9,
            _ => 12
        };

        #endregion

        #region Four Month Period

        //TODO: docs - original name GetQuadrimestre
        public static int FourMonthPeriod(this DateTime dateTime) => dateTime switch
        {
            _ when (dateTime.Month <= 4) => 1,
            _ when (dateTime.Month <= 8) => 2,
            _ => 3
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

        //TODO: docs - original name GetLastMonthInQuadrimestre
        public static int LastMonthOfFourMonthPeriod(this DateTime dateTime) => dateTime.FourMonthPeriod() switch
        {
            1 => 4,
            2 => 8,
            _ => 12
        };

        #endregion
    }
}
