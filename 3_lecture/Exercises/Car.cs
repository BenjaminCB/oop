using System;

namespace Exercises
{
    /*
     * difference between these two
     * https://stackoverflow.com/questions/5980780/difference-between-icomparable-and-icomparer/13750277
     */

    class Car : IComparable<Car>
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
    }
}
