

using JSIL.Meta;
using JSIL.Proxy;

namespace System
{
    public class Console
    {
        [JSRuntimeDispatch]
        [JSExternal]
        [JSMutatedArguments()]
        [JSEscapingArguments()]
        public static void WriteLine(params object[] arguments)
        {
            throw new InvalidOperationException();
        }

        [JSRuntimeDispatch]
        [JSExternal]
        [JSMutatedArguments()]
        [JSEscapingArguments()]
        public static void Write(params object[] arguments)
        {
            throw new InvalidOperationException();
        }
    }
}
