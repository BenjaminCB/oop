using System;

namespace Exam.Logic
{
    public class UserBalanceWarningEventArgs : EventArgs
    {
        public User User { get; }

        public UserBalanceWarningEventArgs(User user) : base()
        {
            User = user;
        }
    }
}
