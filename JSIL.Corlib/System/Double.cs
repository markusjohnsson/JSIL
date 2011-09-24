
using JSIL;
namespace System
{
    public struct Double
    {
        public static bool IsPositiveInfinity(double value)
        {
            return (bool)Verbatim.Expression("value == double.POSITIVE_INFINITY");
        }

        public static bool IsNegativeInfinity(double value)
        {
            return (bool)Verbatim.Expression("value == double.NEGATIVE_INFINITY");
        }

        public static bool IsNaN(double value)
        {
            return (bool)Verbatim.Expression("isNaN(value)");
        }
    }
}
