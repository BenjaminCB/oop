

namespace exercises
{
    public class Manager : Employee
    {
        public int Bonus;

        public Manager(string name, int salary, int bonus) : base(name, salary)
        {
            Title = "Manager";
            Bonus = bonus;
        }

        public override int CalcYearlySalary() => base.CalcYearlySalary() + Bonus;
    }
}
