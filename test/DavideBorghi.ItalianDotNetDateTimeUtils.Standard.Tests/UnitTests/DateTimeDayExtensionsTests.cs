using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DavideBorghi.ItalianDotNetDateTimeUtils.Standard.Tests.UnitTests
{
    public class DateTimeDayExtensionsTests
    {
        #region Positive

        [Fact]
        public void IsWeekend_true_Saturday()
        {
            Assert.True(new DateTime(2023, 3, 25).IsWeekend());
        }

        [Fact]
        public void IsWeekend_true_Sunday()
        {
            Assert.True(new DateTime(2023, 3, 26).IsWeekend());
        }

        #endregion

        #region Negative

        [Fact]
        public void IsWeekend_false_other_week_day() 
        {
            Assert.False(new DateTime(2023, 3, 24).IsWeekend());
        }

        #endregion
    }
}
