
using JSIL.Meta;
namespace System
{
    public class Console
    {
        [JSReplacement("JSIL.Host.logWriteLine($line)")]
        public extern static void WriteLine(string line);
    }
}
