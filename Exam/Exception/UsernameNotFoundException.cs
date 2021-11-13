namespace Exam.Exception
{
    public class UsernameNotFoundException : System.Exception
    {
        public UsernameNotFoundException(string username)
            : base($"No user with the username {username} found in the system") {}
    }
}
