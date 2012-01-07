
using JSIL;

namespace System
{
    public struct Single
    {
        public static bool IsNaN(float value)
        {
            return (bool)Verbatim.Expression("isNaN(value)");
        }

        public static float Parse(string shortRep, Globalization.NumberFormatInfo nfi)
        {
            throw new NotImplementedException();
        }
    }
}
