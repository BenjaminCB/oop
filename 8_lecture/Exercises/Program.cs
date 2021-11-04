using System;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Sequence s = new Sequence(1, 10, 2);
            foreach (int n in s)
            {
                Console.WriteLine(n);
            }

            RandomNNumbers rs = new RandomNNumbers(10, 0, 10);
            foreach (int r in rs)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
