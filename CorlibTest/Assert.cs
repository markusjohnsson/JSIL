using System;
using JSIL.Meta;
using JSIL;
using System.Text;
using System.Collections.Generic;

namespace CorlibTest
{
    public class Assert
    {
        public static void AreEqual(object expected, object actual)
        {
            if (Object.ReferenceEquals(expected, actual))
            {
                return;
            }

            if (!expected.Equals(actual))
            {
                throw new Exception("Assertion failed");
            }
        }

        // Work-around for https://github.com/kevingadd/JSIL/issues/60
        public static void AreEqual(string expected, string actual)
        {
            if (expected != actual)
            {
                throw new Exception("Assertion failed");
            }
        }
    }
}
