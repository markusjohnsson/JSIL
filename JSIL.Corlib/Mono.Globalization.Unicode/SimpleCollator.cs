using System;
using System.Collections.Generic;
using System.Text;
using JSIL;

namespace Mono.Globalization.Unicode
{
    class SimpleCollator
    {
        private System.Globalization.CultureInfo ci;

        public SimpleCollator(System.Globalization.CultureInfo ci)
        {
            this.ci = ci;
        }

        internal int Compare(string str1, int offset1, int length1, string str2, int offset2, int length2, System.Globalization.CompareOptions options)
        {
            return (int)Verbatim.Expression(@"str1.substr(offset1, length1) === str2.substr(offset2, offset2, length2)");
        }

        internal System.Globalization.SortKey GetSortKey(string source, System.Globalization.CompareOptions options)
        {
            throw new NotImplementedException();
        }

        internal int IndexOf(string s, char c, int sindex, int count, System.Globalization.CompareOptions opt)
        {
            throw new NotImplementedException();
        }

        internal int LastIndexOf(string s, char c, int sindex, int count, System.Globalization.CompareOptions opt)
        {
            throw new NotImplementedException();
        }

        internal int LastIndexOf(string s1, string s2, int sindex, int count, System.Globalization.CompareOptions opt)
        {
            throw new NotImplementedException();
        }

        internal int IndexOf(string s1, string s2, int sindex, int count, System.Globalization.CompareOptions opt)
        {
            throw new NotImplementedException();
        }

        internal bool IsSuffix(string source, string suffix, System.Globalization.CompareOptions options)
        {
            throw new NotImplementedException();
        }

        internal bool IsPrefix(string source, string prefix, System.Globalization.CompareOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
