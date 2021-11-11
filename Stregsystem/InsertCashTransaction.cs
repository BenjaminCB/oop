namespace Stregsystem
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, int amount)
            : base(user, amount) {}

        public override void Execute() => User.Balance += Amount;
    }
}
