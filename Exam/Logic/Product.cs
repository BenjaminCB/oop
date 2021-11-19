using System;

namespace Exam.Logic
{
    public class Product
    {
        // even though there is an id column in the csv files it seems ilogical
        // to use them as human error is going to occur at some point
        // assignment using a static variable makes sure that does not happen
        public int Id { get; }
        private static int _Id = 1;

        public string Name { get; }

        // price in oere
        private int _Price;
        public int Price
        {
            get => _Price;
            set
            {
                if (value < 0) throw new ArgumentException("Price cannot be negative");
                _Price = value;
            }
        }

        public virtual bool Active { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public Product(string name, int price, bool active)
        {
            Id = _Id++;
            Name = name;
            Price = price;
            Active = active;
            CanBeBoughtOnCredit = false;
        }

        public override string ToString() => $"{Id}: {Name} - {(double) Price / 100} kr";
    }
}
