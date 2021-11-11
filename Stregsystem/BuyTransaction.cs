using Stregsystem.Exception;

namespace Stregsystem
{
    public class BuyTransaction : Transaction
    {
        public BuyTransaction(User user, int amount) : base(user, amount)
        {
            if (amount < 0) throw new InsertNegativeAmountException();
        }

        public override void Execute() => User.Balance += Amount;
    }
}
