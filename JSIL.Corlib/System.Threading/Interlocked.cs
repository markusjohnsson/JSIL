
using JSIL.Meta;
namespace System.Threading
{
    public class Interlocked
    {
        [JSExternal]
        [JSRuntimeDispatch]
        public static object CompareExchange(ref object destination, object value, object comparand)
        {
            throw new InvalidOperationException();
        }

        [JSExternal]
        [JSRuntimeDispatch]
        public static Int32 CompareExchange(ref Int32 location1, Int32 value, Int32 comparand, ref Boolean succeeded)
        {
            throw new InvalidOperationException();
        }
    }
}
