
namespace System
{
    public struct Char
    {
        public static bool IsDigit(string source, int index)
        {
            var c = source[index];
            return IsDigit(c);
        }

        public static bool IsWhiteSpace(string source, int index)
        {
            return IsWhiteSpace(source[index]);
        }

        public static bool IsDigit(char c)
        {
            return "0123456789"
                .Contains(c);
        }

        public static bool IsLetter(char p)
        {
            return "abcdefghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVXYZ"
                .Contains(p);
        }

        public static bool IsWhiteSpace(char p)
        {
            return " \n\r\t"
                .Contains(p);
        }

        internal static char ToLowerInvariant(char p)
        {
            throw new NotImplementedException();
        }
    }
}
