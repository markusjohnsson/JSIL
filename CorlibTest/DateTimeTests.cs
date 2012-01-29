using System;
using JSIL.Meta;
using JSIL;
using System.Text;
using System.Collections.Generic;

namespace CorlibTest
{
    public static class DateTimeTests
    {
        public static void Run()
        {
            var x = new List<DateTime>() { new DateTime(2012, 1, 1, 0, 0, 0) };
            Assert.AreEqual("01/01/2012 00:00:00", x[0].ToString());
        }
    }
}
