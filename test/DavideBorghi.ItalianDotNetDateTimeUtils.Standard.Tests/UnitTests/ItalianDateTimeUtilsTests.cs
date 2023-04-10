using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DavideBorghi.ItalianDotNetDateTimeUtils.Standard.Tests.UnitTests
{
    public sealed class ItalianDateTimeUtilsTests
    {
        #region Counting days utility

        //TODO: methood with exception
        //TODO: method with different inline data

        #endregion


        #region Working days

        //TODO: method throwing exception

        [Theory]
        [InlineData("2023/01/01", "2023/01/31", 21)]
        public void WorkingDays_BetweenGivenDates_MustBeAsExpected_OnlyNationalHolidays(DateTime startDate,  DateTime endDate, int expectedWorkingDays)
        {
            Assert.Equal(ItalianDateTimeUtils.HowManyWorkingDaysBetweenDates(startDate, endDate), expectedWorkingDays);
        }

        //[Theory]
        //[InlineData("2023/01/01", "2023/06/30", 150)]
        //public void WorkingDays_BetweenGivenDates_MustBeAsExpected_WithLocalHolidays(DateTime startDate, DateTime endDate, int expectedWorkingDays)
        //{
        //    ItalianDateTimeUtils.LocalHolidays = LocalHolidays;
        //    Assert.Equal(ItalianDateTimeUtils.HowManyWorkingDaysBetweenDates(startDate, endDate), expectedWorkingDays);
        //}

        #endregion
    }
}
