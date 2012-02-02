using System;
using System.Collections.Generic;
using System.Text;

namespace System.Runtime.CompilerServices
{
    public class ExtensionAttribute: Attribute
    { }
}

namespace CorlibTest
{
    public static class SimpleLinq
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var s in source)
                yield return selector(s);
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var s in source)
                if (predicate(s))
                    yield return s;
        }

        public static int Sum(this IEnumerable<int> source)
        {
            var sum = 0;
            foreach (var s in source)
                sum += s;
            return sum;
        }

        public static IEnumerable<int> Range(int length)
        {
            for (int i = 0; i < length; i++)
            {
                yield return i;
            }
        }
    }

    class LinqTest
    {
        public static void Run()
        {
            Console.WriteLine("LinqTest");
            Console.WriteLine(SimpleLinq.Range(10).Where(i => i % 2 == 0).Sum());
        }
    }
}
