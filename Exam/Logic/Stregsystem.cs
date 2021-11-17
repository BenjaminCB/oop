using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Exam.Parser;
using Exam.Exception;

namespace Exam.Logic
{
    public class Stregsystem : IStregsystem
    {
        public List<User> Users { get; }
        public List<Product> Products { get; }
        public List<Transaction> Transactions { get; }
        private string _LogFile;

        public Stregsystem()
        {
            // Got errors when typecasting IEnumerable<User> to List<User>
            // so doing it this way
            // Parse orders from file
            FileInfo userFile = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "users.csv"));
            UserCSVParser userParser = new UserCSVParser(userFile, ',');
            var us = userParser.Parse();

            Users = new List<User>();
            foreach (User u in us)
                Users.Add(u);

            // Parse products from file
            FileInfo productFile = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "products.csv"));
            ProductCSVParser productParser = new ProductCSVParser(productFile, ';');
            var ps = productParser.Parse();

            Products = new List<Product>();
            foreach(Product p in ps)
                Products.Add(p);

            Transactions = new List<Transaction>();
            _LogFile = Path.Combine(Directory.GetCurrentDirectory(), "Data", "TransactionLog");
        }

        public void AddUser(User user) => Users.Add(user);

        public BuyTransaction BuyProduct(User user, Product product) =>
            new BuyTransaction(user, product);

        public InsertCashTransaction AddCreditsToAccount(User user, int amount) =>
            new InsertCashTransaction(user, amount);

        // TODO find out if i want try catch here or later
        public void ExecuteTransaction(Transaction t)
        {
            t.Execute();
            Transactions.Add(t);
            if (t.User.Balance < 500)
            {
                UserBalanceWarningEventArgs args = new UserBalanceWarningEventArgs();
                args.User = t.User;
                OnUserBalanceWorning(args);
            }

            // TODO check if this writes everything and overwrites on restart
            // Probably should do this async
            using StreamWriter file = File.AppendText(_LogFile);
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

        public event EventHandler<UserBalanceWarningEventArgs> UserBalanceWarning;

        private void OnUserBalanceWorning(UserBalanceWarningEventArgs e)
        {
            if (UserBalanceWarning != null) UserBalanceWarning(this, e);
        }
    }
}
