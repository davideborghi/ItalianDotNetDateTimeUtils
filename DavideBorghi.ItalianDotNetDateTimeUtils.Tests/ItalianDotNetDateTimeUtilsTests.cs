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
            res = ItalianDotNetDateTimeUtils.GetGiornoOfYearFromString("17032011", 2020);
            Assert.AreEqual(new DateTime(2011, 03, 17), res);
        }
        [TestMethod]
        public void IsFestivo()
        {
            Assert.IsFalse(ItalianDotNetDateTimeUtils.IsFestivo(new DateTime(2020, 02,05)));
            Assert.IsTrue(ItalianDotNetDateTimeUtils.IsFestivo(new DateTime(2020, 01, 01)));
            //Test su festivo locale
            Assert.IsFalse(ItalianDotNetDateTimeUtils.IsFestivo(new DateTime(2020, 06, 24)));
            ItalianDotNetDateTimeUtils.giorniFestiviLocaliList.Add("2406");
            Assert.IsTrue(ItalianDotNetDateTimeUtils.IsFestivo(new DateTime(2020, 06, 24)));

        }
        [TestMethod]
        public void IsWeekend()
        {
            Assert.IsFalse(ItalianDotNetDateTimeUtils.IsWeekend(new DateTime(2020, 02, 06)));
            Assert.IsTrue(ItalianDotNetDateTimeUtils.IsWeekend(new DateTime(2021, 02, 06)));

        }

        [TestMethod]
        public void StartOfWeek()
        {
            Assert.AreEqual(new DateTime(2021, 2, 1), new DateTime(2021, 2, 6).StartOfWeek());
        }

        [TestMethod]
        public void GetDateLavorativaFromEndOfMonthSkipNDays()
        {
            Assert.AreEqual(new DateTime(2021,06,25),ItalianDotNetDateTimeUtils.GetDateLavorativaFromEndOfMonthSkipNDays(new DateTime(2021, 06, 15), 4));
            Assert.AreEqual(new DateTime(2021, 06, 23), ItalianDotNetDateTimeUtils.GetDateLavorativaFromEndOfMonthSkipNDays(new DateTime(2021, 06, 15), 5));
        }
    }
}
