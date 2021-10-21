using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercises
{
    static class HandyMethods
    {
        public static T Max<T>(List<T> ts) where T : IComparable<T> =>
            ts.Aggregate(ts[0], (max, next) => max.CompareTo(next) > 0 ? max : next);

        public static T Min<T>(List<T> ts) where T : IComparable<T> =>
            ts.Aggregate(ts[0], (max, next) => max.CompareTo(next) > 0 ? next : max);

        public static void Copy<T>(T[] source, T[] target)
        {
            if (source.Length != target.Length)
                throw new ArgumentException("Arrays have to have an equal length");

            for (int i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }

        public static void Shuffle<T>(T[] arr)
        {
            Random rnd = new Random();
            int len = arr.Length;

            for (int n = 0; n < len; n++)
            {
                int i = rnd.Next(len) % len,
                    j = rnd.Next(len) % len;

                Swap(arr[i], arr[j]);
            }
        }

        public static void Swap<T>(T a, T b)
        {
            T swap = a;
            a = b;
            b = swap;
        }
    }
}
