using System.Collections.Generic;

namespace exercises
{
    abstract class PassTHroughtFilter : PersonFilter
    {
        // i don't really get what is meant by the exercise be
        // but now everything just runs through the filter
        public sealed override List<Person> Filter(List<Person> pList)
        {
            foreach (Person p in pList)
                FilterPredicate(p);
            return pList;
        }
    }
}
