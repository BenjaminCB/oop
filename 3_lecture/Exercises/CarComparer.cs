using System;
using System.Collections.Generic;

namespace Exercises
{
    class CarComparer : IComparer<Car>
    {
        public CarComparer(){}

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
