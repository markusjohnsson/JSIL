
using JSIL.Meta;
using JSIL.Proxy;
namespace System
{
    public static class Math
    {
        [JSRuntimeDispatch]
        [JSExternal]
        public extern static AnyType Min(params AnyType[] arguments);

        public static int Min(int first, int second)
        {
            return first < second ? first : second;
        }

        [JSReplacement("Math.max($a, $b)")]
        public extern static int Max(int a, int b);

        [JSReplacement("Math.max($a, $b)")]
        public extern static double Max(double a, double b);

        [JSReplacement("Math.abs($value)")]
        public extern static int Abs(int value);

        [JSReplacement("$value.compare(goog.math.Long.ZERO) >= 0 ? $value : $value.neg()")]
        public extern static long Abs(long value);

        [JSReplacement("$value < 0 ? -1 : $value > 0 ? 1 : 0")]
        public extern static int Sign(double value);

        [JSReplacement("Math.abs($value)")]
        public extern static float Abs(float value);

        [JSReplacement("Math.abs($value)")]
        public extern static double Abs(double value);

        [JSReplacement("Math.sqrt($d)")]
        public extern static double Sqrt(double d);

        [JSReplacement("Math.cos($d)")]
        public extern static double Cos(double d);

        [JSReplacement("Math.sin($d)")]
        public extern static double Sin(double d);

        [JSReplacement("Math.tan($d)")]
        public extern static double Tan(double d);

        [JSReplacement("Math.round($d)")]
        public extern static double Round(double d);

        [JSReplacement("Math.floor($d)")]
        public extern static double Floor(double d);

        [JSReplacement("Math.ceil($d)")]
        public extern static double Ceiling(double d);

        [JSReplacement("Math.abs($value)")]
        public extern static double Pow(double p, int num_parsed);
        
        [JSReplacement("Math.abs($value)")]
        public extern static double Log(double p);
    }
}
