using System.Collections.Generic;

namespace exercises
{
    abstract class PersonFilter
    {
        public abstract bool FilterPredicate(Person person);
        public virtual List<Person> Filter(List<Person> pList)
        {
            List<Person> FilteredPList = new List<Person>();

            foreach (Person p in pList)
            {
                if (FilterPredicate(p)) FilteredPList.Add(p);
            }

            return FilteredPList;
        }
    }
}
