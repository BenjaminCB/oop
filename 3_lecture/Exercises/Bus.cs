namespace Exercises
{
    public class Bus: Vehicle, ITaxable
    {
        protected int numberOfSeats;

        public Bus(int numberOfSeats, int regNumber, decimal value)
        :   base(regNumber, 80, value)
        {
            this.numberOfSeats = numberOfSeats;
        }

        public int NumberOfSeats
        {
            get => numberOfSeats;
        }

        public decimal TaxValue() => (decimal) 0.1 * numberOfSeats * value;
    }
}
