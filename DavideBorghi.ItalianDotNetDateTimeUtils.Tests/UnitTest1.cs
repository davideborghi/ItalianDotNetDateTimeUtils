using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DavideBorghi.ItalianDotNetDateTimeUtils.Tests
{
    [TestClass]
    public class DateTimeUtilsTests
    {
        [TestMethod]
        public void GetGiornoFestivoOfYearTest()
        {
            DateTime res = GetGiornoFestivoOfYear("0101", 2018);

        }
    }
}
