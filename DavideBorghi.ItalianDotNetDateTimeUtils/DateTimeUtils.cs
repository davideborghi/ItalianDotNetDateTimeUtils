﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavideBorghi.ItalianDotNetDateTimeUtils
{
	public static class DateTimeUtils
	{
		public static List<string> giorniFestiviList = new List<string>
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
			"2612"
		};
		private static DateTime[] giorniFestivi = new DateTime[giorniFestiviList.Count];

		public static DateTime GetGiornoFestivoOfYear(string dateAsString, int year)
        {
			int giorno = int.Parse(dateAsString.Substring(0, 2));
			int mese = int.Parse(dateAsString.Substring(2, 2));
			return new DateTime(year, mese, giorno);
        }

		public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek = DayOfWeek.Monday)
		{
			int num = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
			return dt.AddDays(-1 * num).Date;
		}

		public static DateTime EndOfWeek(this DateTime dt, DayOfWeek startOfWeek = DayOfWeek.Monday)
		{
			return StartOfWeek(dt).AddDays(6.0);
		}

		public static DateTime GetLastDayOfMonth(this DateTime dateTime)
		{
			return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
		}

		public static DateTime GetFirstDayOfMonth(this DateTime dateTime)
		{
			return new DateTime(dateTime.Year, dateTime.Month, 1);
		}


		public static int HowManyWorkingDaysBetweenDates(this DateTime startDate, DateTime endDate, DateTime[] additionalGiorniFestivi = null)
		{
			int num = 0;
			DateTime dateTime = ((startDate < endDate) ? startDate : endDate);
			DateTime dateTime2 = ((startDate < endDate) ? endDate : startDate);
			while (dateTime <= dateTime2)
			{
				if (!IsFestivo(dateTime, giorniFestivi) || !IsFestivo(dateTime, additionalGiorniFestivi))
				{
					num++;
				}
				dateTime = dateTime.AddDays(1.0);
			}
			return num;
		}

		public static bool IsFestivo(this DateTime dateTime, DateTime[] giorniFestivi)
		{
			if (giorniFestivi == null)
            {
				return false;
            }
			return IsWeekend(dateTime) || giorniFestivi.Contains(dateTime) || GetEasterSunday(dateTime).AddDays(1.0) == dateTime;
		}

		public static bool IsWeekend(this DateTime giorno)
		{
			return giorno.DayOfWeek == DayOfWeek.Saturday || giorno.DayOfWeek == DayOfWeek.Sunday;
		}

		public static DateTime GetEasterSunday(this DateTime dateTime)
		{
			int year = dateTime.Year;
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
