namespace Exam.Exception
{
    public class InvalidUsernameException : System.Exception
    {
        // TODO make the exception be more descriptive of the error
        public InvalidUsernameException()
            : base("This is an invalid username") {}
    }
}
