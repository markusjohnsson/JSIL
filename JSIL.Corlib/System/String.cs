
using JSIL.Meta;
using JSIL;
using System.Globalization;
using System.Runtime.CompilerServices;
namespace System
{
    public class String
    {
        public String()
        {
        }

        public String(char c, int count)
        {
            
        }

        public String(char[] chars): this(chars, 0, chars.Length)
        {
        }

        public String(char[] chars, int startIndex, int length)
        {
            Verbatim.Expression(@"
                var arr = chars.slice(startIndex, length);
                return arr.join("""");
            ");
        }

        [JSReplacement("$this.indexOf(p)")]
        public extern int IndexOf(char p);

        [JSReplacement("($this.indexOf(p) !== -1)")]
        public extern bool Contains(char p);

        [JSReplacement("$left === $right")]
        public extern static bool operator ==(string left, string right);

        [JSReplacement("$left !== $right")]
        public extern static bool operator !=(string left, string right);

        public static String Concat(String str0, String str1, String str2)
        {
            return _Concat(str0, str1, str2);
        }

        public static String Concat(String str0, String str1, String str2, String str3)
        {
            return _Concat(str0, str1, str2, str3);
        }

        public static String Concat(String str0, String str1)
        {
            return _Concat(str0, str1);
        }

        public static String Concat(String str0, object str1)
        {
            return _Concat(str0, str1.ToString());
        }

        public static String Concat<T>(String str0, T str1)
        {
            return _Concat(str0, str1.ToString());
        }

        public static String Concat(object str0, object str1)
        {
            return _Concat(str0, str1.ToString());
        }

        public static String Concat(object str0, object str1, object str2)
        {
            return _Concat(str0.ToString(), str1.ToString(), str2.ToString());
        }

        public static string Concat(params string[] strings)
        {
            return _Concat(strings);
        }

        public static string Concat(params object[] strings)
        {
            return _Concat(strings);
        }

        internal static string _Concat(params object[] strings)
        {
            return (string)Verbatim.Expression("strings.join(\"\")");
        }

        [JSChangeName("length")]
        public extern int Length
        {
            get;
        }

        [IndexerName("Chars")]
        public char this[int idx]
        {
            get
            {
                return (char)Verbatim.Expression("this.substr(idx,1)");
            }
        }

        public override string ToString()
        {
            return this;
        }

        [JSReplacement("JSIL.StringFormat.apply($format, $p)")]
        public extern static string Format(string format, int p);

        internal void InternalSetChar(int index, char value)
        {
            Verbatim.Expression("this.substr(0,index) + chr + this.substr(index+1)");
        }

        public static readonly string Empty = "";
        
        internal static string CharCopyJoin(string dest, int targetIndex, char[] source, int startIndex, int length)
        {
            return CharCopyJoin(dest, targetIndex, new String(source), startIndex, length);
        }

        internal static string InternalAllocateStr(int length)
        {
            return new String(new char[length]);
        }

        internal static string CharCopyJoin(string dest, int targetIndex, string source, int startIndex, int length)
        {
            return (string)Verbatim.Expression(@"dest.substr(0, targetIndex) + source.substr(startIndex, length)");
        }

        internal string SubstringUnchecked(int startIndex, int length)
        {
            return (string)Verbatim.Expression("this.substr(startIndex, length)");
        }

        public string Substring(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex > Length)
                throw new ArgumentOutOfRangeException("startIndex");

            if (startIndex + count > Length)
                throw new ArgumentOutOfRangeException("count");

            return SubstringUnchecked(startIndex, count);
        }

        public string Substring(int startIndex)
        {
            if (startIndex < 0 || startIndex > Length)
                throw new ArgumentOutOfRangeException("startIndex");

            return (string)Verbatim.Expression("this.substr(startIndex)");
        }

        public string Replace(string oldValue, string newValue)
        {
            return (string)Verbatim.Expression("this.replace(oldValue, newValue)");
        }

        [JSChangeName("toLowerCase")]
        public extern string ToLowerInvariant();

        public static string Format(string format, params object [] objs)
        {
            throw new NotImplementedException();
        }

        public string TrimStart(params char[] trimChars)
        {
            throw new NotImplementedException();
        }

        public string TrimEnd(params char[] trimChars)
        {
            throw new NotImplementedException();
        }

        public static bool IsNullOrEmpty(string s)
        {
            throw new NotImplementedException();
        }

        public bool EndsWith(string p)
        {
            throw new NotImplementedException();
        }

        public bool StartsWith(string p)
        {
            throw new NotImplementedException();
        }

        public string[] Split(char p)
        {
            throw new NotImplementedException();
        }

        public string[] Split(char[] p, int p_2)
        {
            throw new NotImplementedException();
        }

        public string Trim()
        {
            if (Length == 0)
                return String.Empty;
            int start = FindNotWhiteSpace(0, Length, 1);

            if (start == Length)
                return String.Empty;

            int end = FindNotWhiteSpace(Length - 1, start, -1);

            int newLength = end - start + 1;
            if (newLength == Length)
                return this;

            return SubstringUnchecked(start, newLength);
        }

        private int FindNotWhiteSpace(int pos, int target, int change)
        {
            while (pos != target)
            {
                char c = this[pos];
                if (c < 0x85)
                {
                    if (c != 0x20)
                    {
                        if (c < 0x9 || c > 0xD)
                            return pos;
                    }
                }
                else
                {
                    if (c != 0xA0 && c != 0xFEFF && c != 0x3000)
                    {
                        if (c != 0x85 && c != 0x1680 && c != 0x2028 && c != 0x2029
#if NET_2_1
                            // On Silverlight this whitespace participates in Trim
                            && c != 0x202f && c != 0x205f
#endif
)
                            if (c < 0x2000 || c > 0x200B)
                                return pos;
                    }
                }
                pos += change;
            }
            return pos;
        }
    }
}
