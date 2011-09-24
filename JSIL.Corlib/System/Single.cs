
using JSIL;

namespace System
{
    public struct Single
    {
        public static bool IsNaN(float value)
        {
            return (bool)Verbatim.Expression("isNaN(value)");
        }
    }
}
