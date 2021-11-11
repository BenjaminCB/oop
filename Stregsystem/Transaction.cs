using System;

namespace Stregsystem
{
    public abstract class Transaction
    {
        public int Id { get; }
        private static int _Id = 1;

        public User User { get; }
        public DateTime Date { get; }
        public int Amount { get; }

        public Transaction(User user, int amount)
        {
            Id = _Id++;
            User = user;
            Amount = amount;
            Date = DateTime.Now;
        }

        public abstract void Execute();

        public override string ToString() =>
            $"{User} made {this.GetType().Name} ({Id}) for {Amount} at {Date}";
    }
}
