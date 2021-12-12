namespace Exam.Exception
{
    public class InvalidEmailException : System.Exception
    {
        public string Email { get; }

        public InvalidEmailException(string email)
            : base($"{email} is an invalid email")
        {
            Email = email;
        }
    }
}
