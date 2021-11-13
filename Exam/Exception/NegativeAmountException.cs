namespace Exam.Exception
{
    public class NegativeAmountException : System.Exception
    {
        // TODO make the exception be more descriptive of the error
        public NegativeAmountException()
            : base("You can not insert a negative amount of money to a user balance") {}
    }
}
