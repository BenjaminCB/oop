using System;
using System.Linq;
using System.Collections.Generic;

namespace Stregsystem
{
    public class Product
    {
        public int Id { get; }
        private static int _Id = 1;

        public string Name { get; }

        // price in oere
        private int _Price;
        // TODO price cannot be negative
        public int Price
        {
            get => _Price;
            set
            {
                pricesAt.Add((value, DateTime.Now));
                _Price = value;
            }
        }
        private List<(int, DateTime)> pricesAt;

        public virtual bool Active { get; set; }
        public bool CanBeBoughtOnCredit { get; }

        public Product(string name, int price, bool canBeBoughtOnCredit)
        {
            Id = _Id++;
            Name = name;
            pricesAt = new List<(int, DateTime)>();
            _Price = price;
            Active = true;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public int GetPriceAt(DateTime date) =>
            pricesAt.SkipWhile(t => t.Item2 < date).First().Item1;

        public override string ToString() => $"{Id}: {Name} - {(double) Price / 100} kr";
    }
}
