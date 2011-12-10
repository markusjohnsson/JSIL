

namespace System
{
    public class Console
    {
        public extern static void WriteLine(string line);
        public static void WriteLine(object o)
        {
            WriteLine(o.ToString());
        }

    }
}
