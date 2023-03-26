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

        #endregion

        #region Private Methods



        #endregion
    }
}
