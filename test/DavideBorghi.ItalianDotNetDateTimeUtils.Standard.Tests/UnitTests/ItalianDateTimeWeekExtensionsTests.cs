using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DavideBorghi.ItalianDotNetDateTimeUtils.Standard.Tests.UnitTests
{
    public class ItalianDateTimeWeekExtensionsTests
    {
        #region Positive

        [Fact]
        public void StartOfWeek_must_be_equal()
        {
            Assert.Equal(new DateTime(2023, 3, 20), new DateTime(2023, 3, 21).StartOfWeek());
        }

        [Fact]
        public void StartOfWeek_must_be_equal_same_day_same_month_same_year()
        {
            Assert.Equal(new DateTime(2023, 3, 20), new DateTime(2023, 3, 20).StartOfWeek());
        }

        [Fact]
        public void StartOfWeek_must_be_equal_same_week_different_month_different_year()
        {
            Assert.Equal(new DateTime(2023, 1, 1), new DateTime(2023, 3, 21).StartOfWeek());
        }

        [Fact]
        public void StartOfWeek_must_be_equal_same_week_same_month_different_year()
        {
            Assert.Equal(new DateTime(2017, 1, 1), new DateTime(2023, 1, 1).StartOfWeek());
        }

        #endregion

        #region Negative

        [Fact]
        public void StartOfWeek_must_not_be_equal_diffent_day_same_month_same_year()
        {
            Assert.NotEqual(new DateTime(2023, 3, 20), new DateTime(2023, 3, 27).StartOfWeek());
        }

        [Fact]
        public void StartOfWeek_must_not_be_equal_same_day_same_month_different_year()
        {
            Assert.NotEqual(new DateTime(2022, 3, 20), new DateTime(2023, 3, 20).StartOfWeek());
        }

        [Fact]
        public void StartOfWeek_must_not_be_equal_different_month_same_year()
        {
            Assert.NotEqual(new DateTime(2023, 3, 1), new DateTime(2023, 4, 1).StartOfWeek());
        }

        [Fact]
        public void StartOfWeek_must_not_be_equal_different_month_different_year()
        {
            Assert.NotEqual(new DateTime(2022, 3, 1), new DateTime(2023, 3, 1).StartOfWeek());
        }

        #endregion
    }
}
