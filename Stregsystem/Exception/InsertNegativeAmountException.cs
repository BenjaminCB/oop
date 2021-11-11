namespace Stregsystem.Exception
{
    public class InsertNegativeAmountException : System.Exception
    {
        // TODO make the exception be more descriptive of the error
        public InsertNegativeAmountException()
            : base("You can not insert a negative amount of money to a user balance") {}
    }
}
