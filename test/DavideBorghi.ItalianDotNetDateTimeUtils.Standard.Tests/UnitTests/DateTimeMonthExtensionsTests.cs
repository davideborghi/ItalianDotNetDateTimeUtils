using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DavideBorghi.ItalianDotNetDateTimeUtils.Standard.Tests.UnitTests
{
    public class DateTimeMonthExtensionsTests
    {
        #region MonthOfYear

        [Fact]
        public void MonthOfYear_MustBeJanuary()
        {
            Assert.Equal(DateTimeEnums.MonthOfYear.January, new DateTime(2023, 1, 1).MonthOfYear());
        }

        [Theory]
        [InlineData("2023/07/16")]
        public void MonthOfYear_MustBeAsExpected(DateTime datetime, DateTimeEnums.MonthOfYear expectedMonthOfYear = DateTimeEnums.MonthOfYear.July)
        {
            Assert.Equal(datetime.MonthOfYear(), expectedMonthOfYear);
        }

        [Theory]
        [InlineData("2022/01/01", "2022/01/01")]
        [InlineData("2023/07/16", "2023/07/16")]
        [InlineData("2022/07/16", "2023/07/01")]
        [InlineData("2022/07/16", "2022/07/01")]
        public void MonthOfYear_MustBeEqual(DateTime firstDateTime, DateTime secondDateTime)
        {
            Assert.Equal(firstDateTime.MonthOfYear(), secondDateTime.MonthOfYear());
        }

        [Theory]
        [InlineData("2023/06/16", "2023/07/01")]
        public void MonthOfYear_MustBeDifferent(DateTime firstDateTime, DateTime secondDateTime)
        {
            Assert.NotEqual(firstDateTime.MonthOfYear(), secondDateTime.MonthOfYear());
        }

        #endregion

        #region FirstDayOfMonth

        #endregion

        #region LastDayOfMonth

        #endregion
    }
}
