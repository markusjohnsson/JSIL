using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public class Environment
    {
        public static string NewLine
        {
            get { return "\n"; }
        }

        internal static string internalGetEnvironmentVariable(string p)
        {
            throw new NotImplementedException();
        }
    }
}
