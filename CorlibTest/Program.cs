

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
            //var sb = new StringBuilder();
            //sb.Append("foo");
            //sb.Append(123.ToString());
            //var x = sb.ToString();
            //Verbatim.Expression("alert(x)");
            //Console.WriteLine(x);
            //Console.WriteLine(x);

            /*
            string foo = "foo";
            string bar = "bar";

            //Console.WriteLine(foo.StartsWith("f"));
            Console.WriteLine(foo.Length);
            Console.WriteLine(foo + bar);

            double one = Math.Cos(0);

            Console.WriteLine((one + 5).ToString());
            */

            var x = new DateTime(2011, 12, 5, 9, 41, 30).ToString();
            Console.WriteLine(x);
            Console.WriteLine(x);
            Verbatim.Expression("alert(x)");
        }
    }
}
