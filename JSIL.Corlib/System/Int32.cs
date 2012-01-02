
using JSIL.Meta;
namespace System
{
    public struct Int32: IComparable<int>
    {
        public const int MaxValue = 0x7fffffff;
        public const int MinValue = -2147483648;

        [JSReplacement("System.String.Format($format, $this)")]
        public string ToString(string format)
        {
            return String.Format(format, this);
        }

        public int CompareTo(int other)
        {
            return this == other ? 0 :
                this > other ? 1 : -1;
        }
    }
}
