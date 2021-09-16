

namespace exercises
{
    abstract class ParkingRate
    {
        public abstract double Rate { get; protected set; }
        protected double _Rate;

        public double Insert(double coin)
        {
            return coin * Rate;
        }
    }
}

