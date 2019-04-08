using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABB.Flisr.Extensions;
using System.Collections.Generic;
using System.Threading;

namespace ABB.Flisr.UnitTests
{
    public class Helper
    {
        public static IEnumerable<string> Get()
        {
            IEnumerable<string> days = new List<string>
            {
                "poniedzialek",
                "wtorek",
                "sroda",
                "czwartek",
                "piatek",
                "sobota",
                "niedziela"
            };

            return days;
        }

        public static IEnumerable<string> LazyGet()
        {
            yield return "poniedzialek";
            yield return "wtorek";
            yield return "sroda";
            yield return "czwartek";
            yield return "piatek";
            yield return "sobota";
            yield return "niedziela";
           
        }

        public static IEnumerable<int> NumberGet()
        {
            int index=0;

            while (true)
            {
               // Thread.Sleep(TimeSpan.FromSeconds(5));
                yield return index++;
            }
        }
    }

    [TestClass]
    public class ExtensionsUnitTests
    {
        [TestMethod]
        public void ListTest()
        {
            var days = Helper.Get();

            foreach  (string day in days)
            {

            }

        }

        [TestMethod]
        public void LazyListTest()
        {
            var days = Helper.LazyGet();

            foreach (string day in days)
            {

            }

        }

        [TestMethod]
        public void LazyNumbersTest()
        {
            var numbers = Helper.NumberGet();

            foreach (int number in numbers)
            {

            }

        }


        [TestMethod]
        public void TestMethod1()
        {

            // bool isHoliday = DateTimeHelper.IsHoliday(DateTime.Today);

            bool isHoliday = DateTime.Today.IsHoliday();

            DateTime.Today.AddWorkDays(7);

        }
    }
}
