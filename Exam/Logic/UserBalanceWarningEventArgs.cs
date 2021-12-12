using System;

namespace Exam.Logic
{
    public class UserBalanceWarningEventArgs : EventArgs
    {
        public int Balance { get; set; }

        public UserBalanceWarningEventArgs(int balance) : base()
        {
            Balance = balance;
        }
    }
}
