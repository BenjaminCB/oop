namespace exercises
{
    class AgeFilter : PersonFilter
    {
        public int MinAge
        {
            get => _MinAge;
            private set => _MinAge = value;
        }
        private int _MinAge;

        public int MaxAge
        {
            get => _MaxAge;
            private set => _MaxAge = value;
        }
        private int _MaxAge;

        public AgeFilter(int min, int max)
        {
            MinAge = min;
            MaxAge = max;
        }

        public override bool FilterPredicate(Person p) => p.Age >= MinAge && p.Age <= MaxAge;
    }
}
