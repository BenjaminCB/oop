using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Exam.Exception;

namespace Exam.Logic
{
    public class StregsystemController : IStregsystem
    {
        public List<User> Users { get; }
        public List<Product> Products { get; }
        public List<Transaction> Transactions { get; }
        private string _LogFile;

        public StregsystemController()
        {
            Users = new List<User>();
            Products = new List<Product>();
            Transactions = new List<Transaction>();
            _LogFile = Path.Combine(Directory.GetCurrentDirectory(), "Data", "TransactionLog");
        }

        public BuyTransaction BuyProduct(User user, Product product) =>
            new BuyTransaction(user, product);

        public InsertCashTransaction AddCreditsToAccount(User user, int amount) =>
            new InsertCashTransaction(user, amount);

        // TODO find out if i want try catch here or later
        public void ExecuteTransaction(Transaction t)
        {
            t.Execute();
            Transactions.Add(t);

            // TODO check if this writes everything and overwrites on restart
            // Probably should do this async
            using StreamWriter file = new StreamWriter(_LogFile);
            file.WriteLine(t);
        }

        // TODO refactor GetProductById and GetUserByEsername
        public Product GetProductById(int id)
        {
            if (!Products.Exists(p => p.Id == id))
                throw new ProductIdNotFoundException(id);

            return Products.Find(p => p.Id == id);
        }

        public IEnumerable<User> GetUsers(Func<User,bool> predicate) => Users.Where(predicate);

        public User GetUserByUsername(string username)
        {
            if (!Users.Exists(u => u.Username == username))
                throw new UsernameNotFoundException(username);

            return Users.Find(u => u.Username == username);
        }

        public IEnumerable<Transaction> GetTransactions(User user, int n) =>
            Transactions.Where(t => t.User == user).Reverse().Take(n);

        public IEnumerable<Product> ActiveProducts
        {
            get => Products.Where(p => p.Active);
        }
    }
}
