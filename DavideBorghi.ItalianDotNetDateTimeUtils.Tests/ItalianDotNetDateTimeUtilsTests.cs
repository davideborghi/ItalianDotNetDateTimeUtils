using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DavideBorghi.ItalianDotNetDateTimeUtils.Tests
{
    [TestClass]
    public class ItalianDotNetDateTimeUtilsTests
    {
        [TestMethod]
        public void GetGiornoOfYearFromStringTest()
        {
            DateTime res = ItalianDotNetDateTimeUtils.GetGiornoOfYearFromString("0101", 2020);
            Assert.AreNotEqual(new DateTime(2020, 01, 02), res);
            Assert.AreNotEqual(new DateTime(2019, 01, 01), res);
            Assert.AreEqual(new DateTime(2020, 01, 01), res);
        }
    }
}
