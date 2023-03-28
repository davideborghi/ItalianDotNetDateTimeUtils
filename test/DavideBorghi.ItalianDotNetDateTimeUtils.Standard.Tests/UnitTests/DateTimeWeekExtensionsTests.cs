using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DavideBorghi.ItalianDotNetDateTimeUtils.Standard.Tests.UnitTests
{
    public class DateTimeWeekExtensionsTests
    {
        #region StartOfWeek

        [Theory]
        [InlineData("2023/03/20", "2023/03/20")]
        [InlineData("2023/03/20", "2023/03/21")]
        public void StartOfWeek_MustBeEqual(DateTime firstDateTime, DateTime secondDateTime)
        {
            Assert.Equal(firstDateTime.StartOfWeek(), secondDateTime.StartOfWeek());
        }

        [Theory]
        [InlineData("2023/03/20", "2023/03/27")]
        [InlineData("2022/03/20", "2023/03/20")]
        [InlineData("2022/03/01", "2023/04/01")]
        [InlineData("2023/03/01", "2022/04/01")]
        public void StartOfWeek_MustBeDifferent(DateTime firstDateTime, DateTime secondDateTime)
        {
            Assert.NotEqual(firstDateTime.StartOfWeek(), secondDateTime.StartOfWeek());
        }

        [Theory]
        [InlineData("2023/03/20", "2023/03/27")]
        [InlineData("2022/03/20", "2023/03/20")]
        [InlineData("2022/03/01", "2023/04/01")]
        [InlineData("2023/03/01", "2022/04/01")]
        public void StartOfWeek_WithSameWeekStartDay_MustBeDifferent(DateTime firstDateTime, DateTime secondDateTime)
        {
            Assert.NotEqual(firstDateTime.StartOfWeek(DayOfWeek.Sunday), secondDateTime.StartOfWeek(DayOfWeek.Sunday));
        }

        [Theory]
        [InlineData("2023/03/20", "2023/03/27")]
        [InlineData("2022/03/20", "2023/03/20")]
        [InlineData("2022/03/01", "2023/04/01")]
        [InlineData("2023/03/01", "2022/04/01")]
        public void StartOfWeek_WithDifferentWeekStartDay_MustBeDifferent(DateTime firstDateTime, DateTime secondDateTime)
        {
            Assert.NotEqual(firstDateTime.StartOfWeek(DayOfWeek.Sunday), secondDateTime.StartOfWeek(DayOfWeek.Tuesday));
        }

        #endregion

        #region EndOfWeek

        [Theory]
        [InlineData("2023/03/20", "2023/03/20")]
        [InlineData("2023/03/20", "2023/03/21")]
        public void EndOfWeek_MustBeEqual(DateTime firstDateTime, DateTime secondDateTime)
        {
            Assert.Equal(firstDateTime.EndOfWeek(), secondDateTime.EndOfWeek());
        }

        [Theory]
        [InlineData("2023/03/20", "2023/03/27")]
        [InlineData("2022/03/20", "2023/03/20")]
        [InlineData("2023/03/01", "2023/04/01")]
        [InlineData("2022/03/01", "2023/04/01")]
        public void EndOfWeek_MustBeDifferent(DateTime firstDateTime, DateTime secondDateTime)
        {
            Assert.NotEqual(firstDateTime.EndOfWeek(), secondDateTime.EndOfWeek());
        }

        #endregion
    }
}
