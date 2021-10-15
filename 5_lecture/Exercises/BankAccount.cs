using System;

namespace Exercises
{
    public class BankAccount
    {
        public int Balance { get; private set; }
        public string Name { get; private set; }

        public BankAccount(string name, int balance)
        {
            Name = name;

            if (balance < 0) throw new InsufficientFundsException();
            Balance = 0;
        }

        public void Deposit(int n)
        {
            if (n < 0) Withdrawel(-n);
            else Balance += n;
        }

        public void Withdrawel(int n)
        {
            if (n < 0)
            {
                Deposit(-n);
            }
            else if (Balance < n)
            {
                throw new InsufficientFundsException();
            }
            else
            {
                Balance -= n;
            }
        }
    }

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() : base("Can't have negative balance") {}
    }
}
