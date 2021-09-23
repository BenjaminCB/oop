using System;
using System.Collections.Generic;

namespace Exercises
{
    /*
     * difference between these two
     * https://stackoverflow.com/questions/5980780/difference-between-icomparable-and-icomparer/13750277
     */

    class Car : IComparable<Car>, IComparer<Car>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        public Car (string make, string model, double price)
        {
            Make = make;
            Model = model;
            Price = price;
        }

        public void Print()
        {
            Console.WriteLine(Make + ", " + Model + ", " + Price);
        }

        public int CompareTo(Car c) => this.Price.CompareTo(c.Price);

        public int Compare(Car a, Car b)
        {
            if (a.Make.CompareTo(b.Make) != 0)
                return a.Make.CompareTo(b.Make);
            else if (a.Model.CompareTo(b.Model) != 0)
                return a.Model.CompareTo(b.Model);
            else
                return a.Price.CompareTo(b.Price);
        }
    }
}
