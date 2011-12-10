using System;
using JSIL.Meta;

namespace CorlibTest
{
    public class Program
    {
        public static void Main()
        {
            double one = Math.Cos(0);

            Console.WriteLine((one + 5).ToString());

            Console.WriteLine(new DateTime(2011, 12, 10));
        }
    }
}
