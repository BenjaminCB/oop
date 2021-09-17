using System;
using System.Collections.Generic;

namespace exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> PS = new List<Person>();
            PS.Add(new Person("Benjamin", "Bennetzen", 21));
            PS.Add(new Person("Peter", "Bennetzen", 21));
            PS.Add(new Person("Tor", "Bennetzen", 21));
            PS.Add(new Person("Gonde", "Bennetzen", 21));
            PS.Add(new Person("Daniel", "Bennetzen", 21));
            PS.Add(new Person("Nikolaj", "Bennetzen", 21));
            PS.Add(new Person("Flemming", "Bennetzen", 21));

            PersonFilter OnName = new NameFilter("Benjamin");
            PersonFilter NotOnName = new NotFilter(OnName);

            List<Person> OnNamePS = OnName.Filter(PS);
            List<Person> NotOnNamePS = NotOnName.Filter(PS);

            foreach (Person p in OnNamePS)
            {
                Console.WriteLine(p.FirstName);
            }

            Console.WriteLine("");

            foreach (Person p in NotOnNamePS)
            {
                Console.WriteLine(p.FirstName);
            }
        }
    }
}
