using System;
using System.Collections.Generic;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() {1, 2, 3, 4, 10, 3, 2, 2};

            Console.WriteLine(HandyMethods.Max(list));

            Tuple<bool, int> tup = new Tuple<bool, int>(true, 10);

            Console.WriteLine(tup.Swap());
            Console.WriteLine(tup.SetFst<string>("hello"));
            Console.WriteLine(tup.SetSnd<Tuple<bool,int>>(tup));

            Console.WriteLine(list.Find(x => x == 5));
        }
    }
}
