namespace exercises
{
    class NameFilter : PersonFilter
    {
        public string Name
        {
            get => _Name;
            private set => _Name = value;
        }
        private string _Name;

        public NameFilter(string name)
        {
            Name = name;
        }

        public override bool FilterPredicate(Person person) => person.FirstName == Name;
    }
}
