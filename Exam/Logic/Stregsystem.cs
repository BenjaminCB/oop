using System;
using System.Collections.Generic;
using System.Linq;
using Exam.Exception;

namespace Exam.Logic
{
    public class StregsystemController
    {
        public List<User> Users { get; }
        public List<Product> Products { get; }
        public List<Transaction> Transactions { get; }

        public StregsystemController()
        {
            Users = new List<User>();
            Products = new List<Product>();
            Transactions = new List<Transaction>();
        }

        public void BuyProduct(User user, Product product) =>
            ExecuteTransaction(new BuyTransaction(user, product));

        public void AddCreditsToAccount(User user, int amount) =>
            ExecuteTransaction(new InsertCashTransaction(user, amount));

        // TODO find out if i want try catch here or later
        public void ExecuteTransaction(Transaction t)
        {
            t.Execute();
            Transactions.Add(t);
        }

        // TODO refactor GetProductById and GetUserByEsername
        public Product GetProductById(int id)
        {
            if (!Products.Exists(p => p.Id == id))
                throw new ProductIdNotFoundException(id);

            return Products.Find(p => p.Id == id);
        }

        public List<User> GetUsers(Func<User,bool> predicate) =>
            (List<User>) Users.Where(predicate);

        public User GetUserByEsername(string username)
        {
            if (!Users.Exists(u => u.Username == username))
                throw new UsernameNotFoundException(username);

            return Users.Find(u => u.Username == username);
        }

        public List<Transaction> GetTransactions(User user, int n) =>
            (List<Transaction>) Transactions.Where(t => t.User == user).Reverse().Take(n);

        public List<Product> ActiveProducts
        {
            get => (List<Product>) Products.Where(p => p.Active);
        }
    }
}
