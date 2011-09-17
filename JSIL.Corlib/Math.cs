
using JSIL.Meta;
using JSIL.Proxy;
namespace System
{
    public static class Math
    {
        [JSRuntimeDispatch]
        [JSExternal]
        public extern static AnyType Min(params AnyType[] arguments);

        [JSRuntimeDispatch]
        [JSExternal]
        public extern static AnyType Max(params AnyType[] arguments);

        [JSReplacement("Math.abs($value)")]
        public extern static AnyType Abs(AnyType value);

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
    }
}
