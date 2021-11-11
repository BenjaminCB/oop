using System;

namespace Stregsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            User u = new User("Benjamin Bennetzen", "bcb", "bbenne20@student.aau.dk");
            Console.WriteLine(u);
            Transaction t = new InsertCashTransaction(u, 1000);
            Console.WriteLine(t);
        }
    }
}
