

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
            Console.WriteLine("Started running tests {0}", DateTime.Now);


            DictionaryTests.Run();
            DateTimeTests.Run();

            Console.WriteLine("Done!");
        }
    }
}
