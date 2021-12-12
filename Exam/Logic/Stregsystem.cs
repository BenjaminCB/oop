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
            // Parse users from file
            FileInfo userFile = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "users.csv"));
            UserCSVParser userParser = new UserCSVParser(userFile, ',');
            Users = userParser.Parse().ToList();

            // Parse products from file
            FileInfo productFile = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "products.csv"));
            ProductCSVParser productParser = new ProductCSVParser(productFile, ';');
            Products = productParser.Parse().ToList();

            Transactions = new List<Transaction>();

            // the file that we write to when a transaction has been executed succesfully
            _LogFile = Path.Combine(Directory.GetCurrentDirectory(), "Data", "TransactionLog.txt");
        }

        public BuyTransaction BuyProduct(User user, Product product) =>
            new BuyTransaction(user, product);

        public InsertCashTransaction AddCreditsToAccount(User user, int amount) =>
            new InsertCashTransaction(user, amount);

        public void ExecuteTransaction(Transaction t)
        {
            // assume that the transaction executes properly otherwise we catch it later
            t.Execute();
            Transactions.Add(t);

            // send UserBalanceWorning event if neccessary
            if (t.User.Balance < 500)
            {
                UserBalanceWarningEventArgs args = new UserBalanceWarningEventArgs();
                args.User = t.User;
                OnUserBalanceWorning(args);
            }

            // not sure if this should append unconditionally or only during program runtime
            using StreamWriter file = File.AppendText(_LogFile);
            file.WriteLine(t);
        }

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
            // if a handler for UserBalanceWarning has been defined call it
            if (UserBalanceWarning != null) UserBalanceWarning(this, e);
        }
    }
}
