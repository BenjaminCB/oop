namespace exercises
{
    class XorFilter : PersonFilter
    {
        private PersonFilter PF1;
        private PersonFilter PF2;

        public XorFilter(PersonFilter pf1, PersonFilter pf2)
        {
            PF1 = pf1;
            PF2 = pf2;
        }

        public override bool FilterPredicate(Person p) =>
            PF1.FilterPredicate(p) ^ PF2.FilterPredicate(p);
    }
}
