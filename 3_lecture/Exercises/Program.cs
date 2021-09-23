using System;
using System.Collections.Generic;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> Cars = new List<Car>()
            {
                new Car("Skoda", "Fabia", 50000),
                new Car("Skoda", "Octavia", 60000),
                new Car("Skoda", "Something", 1000),
                new Car("ABC", "Something", 2000)
            };

            Console.WriteLine(Object.Equals(Cars[0], Cars[1]));

            Cars.Sort();

            foreach (Car c in Cars)
            {
                c.Print();
            }

            List<ITaxable> ITaxables = new List<ITaxable>()
            {
                new House("Aalborg", true, 10, 1000),
                new Bus(10, 1, 500)
            };

            Console.WriteLine();
            foreach (ITaxable IT in ITaxables)
            {
                Console.WriteLine(IT.TaxValue());
            }
        }
    }
}
