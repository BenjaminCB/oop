namespace Exam.Exception
{
    public class InvalidUsernameException : System.Exception
    {
        public string Username { get; }

        public InvalidUsernameException(string username)
            : base($"{username} is an invalid username")
        {
            Username = username;
        }
    }
}
