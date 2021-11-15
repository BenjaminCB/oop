using System;
using System.Collections.Generic;

namespace Exam.Logic
{
    public interface IStregsystem
    {
        IEnumerable<Product> ActiveProducts { get; }
        InsertCashTransaction AddCreditsToAccount(User user, int n);
        BuyTransaction BuyProduct(User user, Product product);
        Product GetProductById(int id);
        IEnumerable<Transaction> GetTransactions(User user, int n);
        IEnumerable<User> GetUsers(Func<User, bool> prodicate);
        User GetUserByUsername(string username);
        // TODO event
        /* event UserBalanceNotification UserBalanceWarning; */
    }
}
