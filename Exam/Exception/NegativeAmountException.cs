namespace Exam.Exception
{
    public class NegativeAmountException : System.Exception
    {
        public NegativeAmountException()
            : base("Transactions do not allow for negative amounts") {}
    }
}
