using System;

namespace person
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Person Mom = new Person("Mom", "Momson", 40);
            Person Dad = new Person("Dad", "Dadson", 50);
            Person Child = new Person("Child", "Childson", 20, Mom, Dad);
            Child.Print();
        }
    }
}
