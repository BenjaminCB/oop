namespace Exercises
{
    public class House: FixedProperty, ITaxable
    {
        protected double _Area;

        public House(string location, bool inCity, double area, decimal value)
        :   base(location, inCity, value)
        {
            this._Area = area;
        }

        public double Area
        {
            get => _Area;
        }

        public decimal TaxValue() => (decimal) 0.1 * estimatedValue * (decimal) Area;
    }
}
