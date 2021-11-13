using System;
using System.Collections.Generic;
using System.Linq;
using Exam.Logic;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            User u = new User("Benjamin Bennetzen", "bcb", "bbenne20@student.aau.dk");
            Console.WriteLine(u);
            Transaction t = new InsertCashTransaction(u, 1000);
            Console.WriteLine(t);

            List<int> ns = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var ns2 = ns.Where(n => n % 2 == 0).Reverse();
            foreach (int n in ns2)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("");
            foreach (int n in ns)
            {
                Console.WriteLine(n);
            }
        }
    }
}
