
namespace System
{
    public struct Int64
    {
        public const long MaxValue = 0x7fffffffffffffff;
        public const long MinValue = -9223372036854775808;

        public static long operator +(Int64 left, Int64 right)
        {
            throw new NotImplementedException();
        }
    }
}
