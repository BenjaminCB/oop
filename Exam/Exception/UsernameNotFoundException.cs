namespace Exam.Exception
{
    public class UsernameNotFoundException : System.Exception
    {
        public string Username { get; }

        public UsernameNotFoundException(string username)
            : base($"No user with the username {username} found in the system")
        {
            Username = username;
        }
    }
}
