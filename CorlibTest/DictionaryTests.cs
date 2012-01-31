using System;
using System.Collections.Generic;
using System.Text;

namespace CorlibTest
{
    class DictionaryTests
    {
        public static void Run()
        {
            Console.WriteLine("DictionaryTests");

            var d = new Dictionary<string, int>
            {
                { "a", 1 },
                { "b", 4 },
                { "c", 7 }
            };

            Assert.AreEqual(3, d.Count);
            Assert.AreEqual(d["a"], 1);
            Assert.AreEqual(d["b"], 4);
            Assert.AreEqual(d["c"], 7);
        }
    }
}
