namespace Stregsystem
{
    public class Product
    {
        public int Id { get; }
        private static int _Id = 1;

        public string Name { get; }

        // price in oere
        // TODO price cannot be negative
        public int Price { get; }

        public virtual bool Active { get; set; }
        public bool CanBeBoughtOnCredit { get; }

        public Product(string name, int price, bool canBeBoughtOnCredit)
        {
            Id = _Id++;
            Name = name;
            Price = price;
            Active = true;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public override string ToString() => $"{Id}: {Name} - {(double) Price / 100} kr";
    }
}
