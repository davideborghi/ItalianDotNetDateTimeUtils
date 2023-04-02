using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DavideBorghi.ItalianDotNetDateTimeUtils.Standard.Tests.UnitTests
{
    public sealed class HolidaysTests
    {
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
    }
}
