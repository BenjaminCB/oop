using System;
using Exam.Exception;

namespace Exam.Logic
{
    public abstract class Transaction
    {
        public int Id { get; }
        private static int _Id = 1;

        public User User { get; }

        public DateTime Date { get; }

        private int _Amount;
        public int Amount
        {
            get => _Amount;
            protected set
            {
                if (value < 0) throw new NegativeAmountException();
                _Amount = value;
            }
        }

        public Transaction(User user, int amount)
        {
            Id = _Id++;
            User = user;
            Amount = amount;
            Date = DateTime.Now;
        }

        public abstract void Execute();

        public override string ToString() =>
            $"{this.GetType().Name} ({Id}) at {Date}: {User} transaction amount {Amount}";
    }
}
