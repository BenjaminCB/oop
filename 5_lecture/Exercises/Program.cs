using System;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(ReadInteger());
        }

        static int ReadInteger()
        {
            try
            {
                return Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("This was not an integer, try again");
                return ReadInteger();
            }
        }
    }
}
