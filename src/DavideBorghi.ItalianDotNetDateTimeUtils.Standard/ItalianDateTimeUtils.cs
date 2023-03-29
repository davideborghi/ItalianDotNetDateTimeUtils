using System;
using System.Collections.Generic;
using System.Text;

namespace DavideBorghi.ItalianDotNetDateTimeUtils.Standard
{
    public static class ItalianDateTimeUtils
    {
        #region Private Fields

        private static DateTime[] _holidays;

        //TODO: si potrebbe trasformare in un dizionario ed offrire un metodo per recuperarle, oppure tipo Enum
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
            "17032011"
        };

        #endregion

        #region Public Fields

        public static List<string>? LocalHolidays;

        #endregion

        #region Public Methods

        //TODO: docs - original name GetGiornoOfYearFromString
        public static DateTime GetDayOfYear(string dateAsString, int year)
        {
            int day = int.Parse(dateAsString[..2]);
            int month = int.Parse(dateAsString.Substring(2, 2));
            year = dateAsString.Length > 4 ? int.Parse(dateAsString.Substring(4, 4)) : year;
            return new DateTime(year, month, day);
        }

        public static DateTime GetEasterOfYear(int year)
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

        #endregion

        #region Private Methods



        #endregion
    }
}
