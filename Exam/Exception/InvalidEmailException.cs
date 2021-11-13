namespace Exam.Exception
{
    public class InvalidEmailException : System.Exception
    {
        // TODO make the exception be more descriptive of the error
        public InvalidEmailException()
            : base("This is an invalid email") {}
    }
}
