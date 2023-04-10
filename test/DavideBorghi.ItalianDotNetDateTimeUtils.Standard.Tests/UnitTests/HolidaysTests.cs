using Xunit;

namespace DavideBorghi.ItalianDotNetDateTimeUtils.Standard.Tests.UnitTests
{
    public sealed class HolidaysTests
    {
        #region Private Fields

        public static IEnumerable<string?> LocalHolidays => new List<string?> { "2406" };

        #endregion

        #region Easter

        [Theory]
        [InlineData(1900, "1900/04/15")]
        [InlineData(1927, "1927/04/17")]
        [InlineData(1951, "1951/03/25")]
        [InlineData(2000, "2000/04/23")]
        [InlineData(2023, "2023/04/09")]
        [InlineData(2049, "2049/04/18")]
        public void Check_If_EasterOfYear_Is_AsExpected(int year, DateTime expectedEasterDateTime)
        {
            DateTime calculatedEasterOfYear = ItalianDateTimeUtils.GetYearlyEaster(year);
            Assert.Equal(calculatedEasterOfYear, expectedEasterDateTime);
        }

        #endregion

        #region Italian Holiday

        [Fact]
        public void XmasIsHoliday()
        {
            Assert.True(ItalianDateTimeUtils.IsHoliday(new DateTime(2023, 12, 25)));
        }

        [Theory]
        [InlineData("1911/03/17")]
        [InlineData("1961/03/17")]
        [InlineData("2011/03/17")]
        [InlineData("2023/01/01")]
        [InlineData("2023/01/06")]
        [InlineData("2024/04/25")]
        [InlineData("2024/05/01")]
        [InlineData("2024/06/02")]
        [InlineData("2024/08/15")]
        [InlineData("2024/11/01")]
        [InlineData("2024/12/08")]
        [InlineData("2024/12/25")]
        [InlineData("2024/12/26")]
        public void Check_If_GivenNationalHolidayDateTime_IsHoliday(DateTime givenDate)
        {
            Assert.True(ItalianDateTimeUtils.IsHoliday(givenDate));
        }

        [Theory]
        [InlineData("2023/06/24")]
        public void Check_If_GivenLocalHolidayDateTime_IsHoliday(DateTime givenDate)
        {
            ItalianDateTimeUtils.LocalHolidays = LocalHolidays;
            Assert.True(ItalianDateTimeUtils.IsHoliday(givenDate));
        }

        [Theory]
        [InlineData("2023/11/04")]
        public void Check_If_GivenLocalHolidayDateTime_IsNotHoliday(DateTime givenDate)
        {
            ItalianDateTimeUtils.LocalHolidays = LocalHolidays;
            Assert.False(ItalianDateTimeUtils.IsHoliday(givenDate));
        }

        #endregion
    }
}
