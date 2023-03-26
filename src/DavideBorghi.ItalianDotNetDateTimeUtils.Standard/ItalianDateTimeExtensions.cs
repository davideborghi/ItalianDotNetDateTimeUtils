using System;
using System.Collections.Generic;
using System.Text;

namespace DavideBorghi.ItalianDotNetDateTimeUtils.Standard
{
    public static class ItalianDateTimeExtensions
    {
        #region Day



        #endregion


        #region Week

        //TODO: docs
        public static DateTime StartOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int num = (7 + (dateTime.DayOfWeek - startOfWeek)) % 7;
            return dateTime.AddDays(-1 * num).Date;
        }

        //TODO: docs
        public static DateTime EndOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            return StartOfWeek(dateTime).AddDays(6.0);
        }

        #endregion

        #region Month

        //TODO: docs - original name GetLastDayOfMonth
        public static DateTime LastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }

        //TODO: docs - original name GetFirstDayOfMonth
        public static DateTime FirstDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        #endregion

        #region Quarter Methods

        //TODO: docs - original name GetTrimestre
        public static int Quarter(this DateTime dateTime) => dateTime switch
        {
            _ when (dateTime.Month <= 3)  => 1,
            _ when (dateTime.Month <= 6) => 2,
            _ when (dateTime.Month <= 9) => 3,
            _ => 4
        };

        //TODO: docs - original name GetFirstDayOfTrimestre
        public static DateTime FirstDayOfQuarter(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.FirstMonthOfQuarter(), 1);
        }

        //TODO: docs - original GetLastDayOfTrimestre
        public static DateTime LastDayOfQuarter(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.LastMonthOfQuarter(), 1).LastDayOfMonth();
        }

        //TODO: docs - original name GetFirstMonthOfTrimestre
        public static int FirstMonthOfQuarter(this DateTime dateTime)
        {
            int currentQuarter = dateTime.Quarter();
            return currentQuarter == 1 ? 1 : currentQuarter == 2 ? 4 : currentQuarter == 3 ? 7 : 10;
        }
        
        //TODO: docs - original name GetLastMonthInTrimestre
        public static int LastMonthOfQuarter(this DateTime dateTime)
        {
            int quarter = dateTime.Quarter();
            return quarter == 1 ? 3 : quarter == 2 ? 6 : quarter == 3 ? 9 : 12;
        }

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
        {
            return new DateTime(dateTime.Year, dateTime.FirstMonthOfFourMonthPeriod(), 1);
        }

        //TODO: docs - original name GetLastDayOfQuadrimestre
        public static DateTime LastDayOfFourMonthPeriod(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.LastMonthOfFourMonthPeriod(), 1).LastDayOfMonth();
        }

        //TODO: docs - original name GetFirstMonthInQuadrimestre
        public static int FirstMonthOfFourMonthPeriod(this DateTime dateTime)
        {
            int fourMonthPeriod = dateTime.FourMonthPeriod();
            return fourMonthPeriod == 1 ? 1 : fourMonthPeriod == 2 ? 5 : 9;
        }

        //TODO: docs - original name GetLastMonthInQuadrimestre
        public static int LastMonthOfFourMonthPeriod(this DateTime dateTime)
        {
            int fourMonthPeriod = dateTime.FourMonthPeriod();
            return fourMonthPeriod == 1 ? 4 : fourMonthPeriod == 2 ? 8 : 12;
        }

        #endregion
    }
}
