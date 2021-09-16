namespace exercises
{
    class NotFilter : PersonFilter
    {
        private PersonFilter PF;

        public NotFilter(PersonFilter pf)
        {
            PF = pf;
        }

        public override bool FilterPredicate(Person p) => !PF.FilterPredicate(p);
    }
}
