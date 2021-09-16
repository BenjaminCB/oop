using System;

namespace exercises
{
    public class Employee
    {
        // there needs to getter and setters on these but i am to lazy
        public string Name;
        public string Title;
        public int Salary;

        public int Seneniority
        {
            get => _Seneiority;
            set
            {
                if (value <= 10 && value >= 0)
                {
                    _Seneiority = value;
                }
                else
                {
                    throw new ArgumentException("Seneniority value is out of bounds");
                }
            }
        }
        protected int _Seneiority = 1;

        public Employee(string name, string title, int salary)
        {
            Name = name;
            Title = title;
            Salary = salary;
        }

        protected Employee(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        public virtual int CalcYearlySalary()
        {
            return (int) (12 * Salary * (1 + (double) (Seneniority / 10)));
        }
    }
}
