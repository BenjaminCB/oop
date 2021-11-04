using System;
using System.Collections;
using System.Collections.Generic;

namespace Exercises
{
    public class RandomNNumbers : IEnumerable<int>
    {
        public int Count { get; private set; }
        public int Max { get; private set; }
        public int Min { get; private set; }
        public int Seed { get; private set; }
        private List<int> numbers;

        public RandomNNumbers(int count, int min, int max)
        {
            Count = count;
            Max = max;
            Min = min;
            Seed = (int) DateTime.Now.Ticks;
            Random rnd = new Random(Seed);
            numbers = new List<int>();
            for (int i = 0; i < count; i++)
            {
                numbers.Add(rnd.Next(min, max));
            }
        }

        public IEnumerator<int> GetEnumerator() => numbers.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
