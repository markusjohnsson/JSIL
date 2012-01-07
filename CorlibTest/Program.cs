

using System;
using JSIL.Meta;
using JSIL;
using System.Text;
using System.Collections.Generic;

namespace CorlibTest
{
    public class Program
    {
        public static void Main()
        {
            var x = new List<DateTime>() { new DateTime(2012, 1, 1, 0, 0, 0) };
            var y = x[0] + TimeSpan.FromDays(40);
            x.Add(y);
            Console.WriteLine(x.ToString());
            Console.WriteLine(x[0]);
            Console.WriteLine(y);
            Console.WriteLine(y);
            var z = x[1];
            Console.WriteLine(z);
            //Verbatim.Expression("alert(y)");
        }
    }
}
