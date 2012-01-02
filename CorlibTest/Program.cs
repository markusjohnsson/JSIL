

using System;
using JSIL.Meta;
using JSIL;
using System.Text;

namespace CorlibTest
{
    public class Program
    {
        public static void Main()
        {
            var x = new DateTime(2012, 1, 1, 0, 0, 0);
            var y = x + TimeSpan.FromDays(40);
            Console.WriteLine(x);
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(y);
            Verbatim.Expression("alert(y)");
        }
    }
}
