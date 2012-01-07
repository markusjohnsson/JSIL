
using JSIL;
namespace System
{
    public struct Double
    {
        public static bool IsPositiveInfinity(double value)
        {
            return (bool)Verbatim.Expression("value == Number.POSITIVE_INFINITY");
        }

        public static bool IsNegativeInfinity(double value)
        {
            return (bool)Verbatim.Expression("value == Number.NEGATIVE_INFINITY");
        }

        public static bool IsNaN(double value)
        {
            return (bool)Verbatim.Expression("isNaN(value)");
        }

        public static double Parse(string shortRep, Globalization.NumberFormatInfo nfi)
        {
            throw new NotImplementedException();
        }
    }
}
