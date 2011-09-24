
using JSIL.Meta;
namespace System
{
    public class Delegate
    {
        [JSExternal]
        public extern static Delegate Combine(Delegate left, Delegate right);

        [JSExternal]
        public extern static Delegate Remove(Delegate source, Delegate value);

    }
}
