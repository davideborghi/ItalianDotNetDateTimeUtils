using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavideBorghi.ItalianDotNetDateTimeUtils
{
    public static class ItalianDotNetDateTimeUtils
    {
        /// <summary>
        /// This variable is used to store national holidays
        /// </summary>
        public static List<string> giorniFestiviNazionaliList = new List<string>
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
        /// <summary>
        /// Variable for local holidays such as "Santo Patrono"
        /// Must be in format ddMM
        /// </summary>
        public static List<string> giorniFestiviLocaliList = new List<string>
        {

        };
        private static List<DateTime> giorniFestivi;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateAsString">the day in format ddMM</param>
        /// <param name="year">the year you want the date</param>
        /// <returns>Return day in DateTime</returns>
        public static DateTime GetGiornoOfYearFromString(string dateAsString, int year)
        {
            int giorno = int.Parse(dateAsString.Substring(0, 2));
            int mese = int.Parse(dateAsString.Substring(2, 2));
            year = dateAsString.Length > 4 ? int.Parse(dateAsString.Substring(4, 4)) : year;
            return new DateTime(year, mese, giorno);
        }
        /// <summary>
        /// return the date of the Monday of the week of the given day
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startOfWeek">Day you start of week, monday is default</param>
        /// <returns>return the date of the Monday of the week of the given day</returns>
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int num = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * num).Date;
        }
        /// <summary>
        /// return the date of the Sunday of the week of the given day
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startOfWeek">Day you start of week, monday is default</param>
        /// <returns>return the date of the Sunday of the week of the given day</returns>
        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            return StartOfWeek(dt).AddDays(6.0);
        }
        /// <summary>
        /// Get the date of the last day of the month of the given date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>date of the last day of the month of the given date</returns>
        public static DateTime GetLastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }
        /// <summary>
        /// Get the date of the first day of the month of the given date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>date of the first day of the month of the given date</returns>
        public static DateTime GetFirstDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }
        /// <summary>
        /// Get the first day of the given "trimestre"
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>datetime representing the first day of trimestre</returns>
        public static DateTime GetFirstDayOfTrimestre(this DateTime dateTime)
        {
            int mese = dateTime.GetFirstMonthInTrimestre();
            return new DateTime(dateTime.Year, mese, 1);
        }
        /// <summary>
        /// Get the last day of the given "trimestre"
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>datetime representing the last day of trimestre</returns>
        public static DateTime GetLastDayOfTrimestre(this DateTime dateTime)
        {
            int mese = dateTime.GetLastMonthInTrimestre();
            var date = new DateTime(dateTime.Year, mese, 1);
            return date.GetLastDayOfMonth();
        }
        /// <summary>
        /// Get the first day of the given "quadrimestre"
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>datetime representing the first day of quadrimestre</returns>
        public static DateTime GetFirstDayOfQuadrimestre(this DateTime dateTime)
        {
            int mese = dateTime.GetFirstMonthInQuadrimestre();
            return new DateTime(dateTime.Year, mese, 1);
        }
        /// <summary>
        /// Get the last day of the given "quadrimestre"
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>datetime representing the last day of quadrimestre</returns>
        public static DateTime GetLastDayOfQuadrimestre(this DateTime dateTime)
        {
            int mese = dateTime.GetLastMonthInQuadrimestre();
            var date = new DateTime(dateTime.Year, mese, 1);
            return date.GetLastDayOfMonth();
        }
        /// <summary>
        /// Get the int representing the quarter (trimestre) of the given date
        /// </summary>
        /// <param name="date"></param>
        /// <returns>int representing the quarter (trimestre)</returns>
        public static int GetTrimestre(this DateTime date)
        {
            if (date.Month <= 3)
                return 1;
            if (date.Month <= 6)
                return 2;
            if (date.Month <= 9)
                return 3;
            return 4;
        }
        /// <summary>
        /// Get the int representing the last month of the trimestre
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetLastMonthInTrimestre(this DateTime date)
        {
            int trimestre = date.GetTrimestre();
            return trimestre == 1 ? 3 : trimestre == 2 ? 6 : trimestre == 3 ? 9 : 12;
        }
        /// <summary>
        /// Get the int representing the first month of the trimestre
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetFirstMonthInTrimestre(this DateTime date)
        {
            int trimestre = date.GetTrimestre();
            return trimestre == 1 ? 1 : trimestre == 2 ? 4 : trimestre == 3 ? 7 : 10;
        }
        public static int GetQuadrimestre(this DateTime date)
        {
            if (date.Month <= 4)
                return 1;
            if (date.Month <= 8)
                return 2;
            return 3;//if (date.Month <= 12)
        }
        /// <summary>
        /// Get the int representing the last month of the trimestre
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetLastMonthInQuadrimestre(this DateTime date)
        {
            int quadrimestre = date.GetQuadrimestre();
            return quadrimestre == 1 ? 4 : quadrimestre == 2 ? 8 : 12;
        }
        /// <summary>
        /// Get the int representing the first month of the trimestre
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetFirstMonthInQuadrimestre(this DateTime date)
        {
            int quadrimestre = date.GetQuadrimestre();
            return quadrimestre == 1 ? 1 : quadrimestre == 2 ? 5 : 9;
        }
        /// <summary>
        /// Ritorna l'n-ultimo giorno lavorivo del mese 
        /// </summary>
        /// <param name="dataDelMese">Data del mese di cui si vuole fare il calcolo</param>
        /// <param name="dayToSkip">Numero di giorni lavorativi di cui si vuole tenere conto</param>
        /// <returns></returns>
        public static DateTime GetDateLavorativaFromEndOfMonthSkipNDays(DateTime dataDelMese, int dayToSkip)
        {
            dataDelMese = GetLastDayOfMonth(dataDelMese);
            DateTime dataRisultato = dataDelMese;
            while (dayToSkip != HowManyWorkingDaysBetweenDates(dataRisultato, dataDelMese))
            {
                dataRisultato = dataRisultato.AddDays(-1);
            }
            return dataRisultato;
        }
        /// <summary>
        /// Get how many working days exists between two dates
        /// </summary>
        /// <param name="startDate">start date for calc</param>
        /// <param name="endDate">end date for calc</param>
        /// <returns></returns>
        public static int HowManyWorkingDaysBetweenDates(DateTime startDate, DateTime endDate)
        {
            int num = 0;
            DateTime dateTime = ((startDate < endDate) ? startDate : endDate);
            DateTime dateTime2 = ((startDate < endDate) ? endDate : startDate);
            int[] years = GetYearsBetweenDates(dateTime, dateTime2);
            foreach (int year in years)
            {
                CalcolaGiorniFestiviPerAnno(year);
            }
            while (dateTime <= dateTime2)
            {
                if (!IsFestivo(dateTime))
                {
                    num++;
                }
                dateTime = dateTime.AddDays(1.0);
            }
            return num;
        }
        /// <summary>
        /// Get array of the year between two dates
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int[] GetYearsBetweenDates(DateTime start, DateTime end)
        {
            List<int> years = new List<int>();
            int startYear = start.Year;
            int endYear = end.Year;
            while (startYear <= endYear)
            {
                years.Add(startYear++);
            }
            return years.ToArray();
        }
        /// <summary>
        /// get if a date is holiday
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsFestivo(this DateTime dateTime)
        {

            giorniFestivi = CalcolaGiorniFestiviPerAnno(dateTime.Year);



            return IsWeekend(dateTime) || giorniFestivi.Contains(dateTime) || GetEasterSunday(dateTime.Year).AddDays(1.0) == dateTime;
        }

        private static List<DateTime> CalcolaGiorniFestiviPerAnno(int year)
        {
            if (giorniFestivi == null)
            {
                giorniFestivi = new List<DateTime>();

            }
            foreach (string giorno in giorniFestiviNazionaliList)
            {
                giorniFestivi.Add(GetGiornoOfYearFromString(giorno, year));
            }

            foreach (string giorno in giorniFestiviLocaliList)
            {
                giorniFestivi.Add(GetGiornoOfYearFromString(giorno, year));
            }
            return giorniFestivi;
        }
        /// <summary>
        /// get if a day is weekend
        /// </summary>
        /// <param name="giorno"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime giorno)
        {
            return giorno.DayOfWeek == DayOfWeek.Saturday || giorno.DayOfWeek == DayOfWeek.Sunday;
        }
        /// <summary>
        /// given a year return the Easter sunday
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>

        public static DateTime GetEasterSunday(int year)
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
    }

}
