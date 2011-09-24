
using JSIL.Meta;
namespace System.Threading
{
    public class Monitor
    {
        [JSExternal]
        [JSRuntimeDispatch]
        public static void Enter(Object o)
        {
            throw new InvalidOperationException();
        }

        [JSExternal]
        [JSRuntimeDispatch]
        public static void Enter(Object o, ref bool lockTaken)
        {
            throw new InvalidOperationException();
        }

        [JSExternal]
        public static void Exit(Object o)
        {
            throw new InvalidOperationException();
        }
    }
}
