using System;

namespace person
{
    class Person
    {
        private string _FirstName;

        public string FirstName
        {
            get => _FirstName;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _FirstName = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be null or empty string", "value");
                }
            }
        }

        private string _LastName;

        public string LastName
        {
            get => _LastName;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _LastName = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be null or empty string", "value");
                }
            }
        }

        public int Age;

        public Person Mom;
        public Person Dad;

        private bool hasMom = false;
        private bool hasDad = false;

        private static int PersonID = 0;
        private int ID;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;

            ID = PersonID;
            PersonID++;
        }

        public Person(string firstName, string lastName, int age, Person mom, Person dad)
               : this(firstName, lastName, age)
        {
            Mom = mom;
            Dad = dad;
            hasMom = true;
            hasDad = true;
        }

        public void Print()
        {
            Console.WriteLine($"Name: { FirstName } { LastName }, age: { Age }, id: { ID }.");
            if (hasMom) Mom.Print();
            if (hasDad) Dad.Print();
        }
    }
}
