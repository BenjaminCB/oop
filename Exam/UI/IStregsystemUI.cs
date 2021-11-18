using System;
using Exam.Logic;

namespace Exam.UI
{
    public interface IStregsystemUI
    {
        void UserNotFound(string username);
        void ProductNotFound(string product);
        void UserInfo(User user);
        void ArgumentsCountError(string command, int n);
        void UserBuysProduct(BuyTransaction transaction);
        void UserBuysProduct(int n, BuyTransaction transaction);
        void Close();
        void InsufficientCash(User user, Product product);
        void GeneralError(string errorString);
        void GeneralMessage(string msg);
        void Start();
        event EventHandler<CommandEnteredEventArgs> CommandEntered;
    }
}
