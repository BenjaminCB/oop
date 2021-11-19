using System;

namespace Exam.Logic
{
    public class UserBalanceWarningEventArgs : EventArgs
    {
        // Add user property to base class EventArgs
        public User User { get; set; }
    }
}
