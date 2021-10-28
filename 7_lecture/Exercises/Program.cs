using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    delegate string StringJoin(string a, string b);
    delegate T Semigroup<T>(T a, T b);

    class Program
    {
        static void Main(string[] args)
        {
            StringJoin ConcatString = (a,b) => a + b;
            Console.WriteLine(ConcatString("hello ", "delegates"));

            List<string> strs = new List<string>() {"hello", "world!", "with", "spacing"};
            Console.WriteLine(JoinAllStrings(strs, (a,b) => a + " " + b));

            int[] xs = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            Console.WriteLine(MyExists<int>(x => x % 2 == 0, xs));
        }

        static string Join3(string a, string b, string c, StringJoin f) => f(f(a,b),b);

        static string JoinAllStrings(List<string> strs, StringJoin f) =>
            strs.Aggregate("", (res, next) => f(res, next));

        static T SConcat<T>(List<T> xs, Semigroup<T> sappend)
        {
            T res = xs[0];
            for (int i = 1; i < xs.Count; i++)
            {
                res = sappend(res, xs[i]);
            }
            return res;
        }

        static bool MyExists<T>(Predicate<T> f, T[] xs) =>
            xs.Aggregate(false, (res, x) => res || f(x));

        static T Twice<T>(Func<T,T> f, T v) => f(f(v));
    }
}
