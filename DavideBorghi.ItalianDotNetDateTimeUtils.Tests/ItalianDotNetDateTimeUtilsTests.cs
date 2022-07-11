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
            ItalianDotNetDateTimeUtils.giorniFestiviLocaliList = new System.Collections.Generic.List<string>();
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
            ItalianDotNetDateTimeUtils.giorniFestiviLocaliList.Add("2406");
            Assert.AreEqual(new DateTime(2021, 06, 23), ItalianDotNetDateTimeUtils.GetDateLavorativaFromEndOfMonthSkipNDays(new DateTime(2021, 06, 15), 5));
        }
        [TestMethod]
        public void GetFirstDayOfTrimestreTest()
        {
            Assert.AreEqual(new DateTime(2022, 07, 01), ItalianDotNetDateTimeUtils.GetFirstDayOfTrimestre(new DateTime(2022, 07, 11)));
        }
        [TestMethod]
        public void GetLastDayOfTrimestreTest()
        {
            Assert.AreEqual(new DateTime(2022, 09, 30), ItalianDotNetDateTimeUtils.GetLastDayOfTrimestre(new DateTime(2022, 07, 11)));
        }
        [TestMethod]
        public void TestGetTrimestre()
        {
            Assert.AreEqual(3, ItalianDotNetDateTimeUtils.GetTrimestre(new DateTime(2022, 7, 11)));
            Assert.AreNotEqual(4, ItalianDotNetDateTimeUtils.GetTrimestre(new DateTime(2022, 7, 11)));
        }
        [TestMethod]
        public void GetFirstDayOfQuadrimestreTest()
        {
            Assert.AreEqual(new DateTime(2022, 05, 01), ItalianDotNetDateTimeUtils.GetFirstDayOfQuadrimestre(new DateTime(2022, 07, 11)));
        }
        [TestMethod]
        public void GetLastDayOfQuadrimestreTest()
        {
            Assert.AreEqual(new DateTime(2022, 08, 31), ItalianDotNetDateTimeUtils.GetLastDayOfQuadrimestre(new DateTime(2022, 07, 11)));
        }
        [TestMethod]
        public void TestGetQuadrimestre()
        {
            Assert.AreEqual(2, ItalianDotNetDateTimeUtils.GetQuadrimestre(new DateTime(2022, 7, 11)));
            
        }
    }
}
