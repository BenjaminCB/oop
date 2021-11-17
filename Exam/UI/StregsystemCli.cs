using System;
using Spectre.Console;
using Exam.Logic;

namespace Exam.UI
{
    public class StregsystemCLI : IStregsystemUI
    {
        private IStregsystem _Stregsystem;
        private Panel _DisplayReponse;
        private bool _Running;

        public StregsystemCLI(IStregsystem stregsystem)
        {
            _Stregsystem = stregsystem;
            _DisplayReponse = new Panel("There have been any responses yet.");;
            _Running = false;
        }

        public void Start()
        {
            if (_Running) return;

            _Running = true;

            Rule header = new Rule("[bold]STREGSYSTEM[/]");
            header.Centered();
            Rule input = new Rule("[bold]INPUT[/]");
            input.Centered();

            Panel instructions = new Panel("These are the instructions");
            instructions.Header = new PanelHeader("[bold]Instructions[/]");

            Panel products = new Panel("These are the products");
            products.Header = new PanelHeader("[bold]Products[/]");

            PanelHeader responseHeader = new PanelHeader("[bold]Responses[/]");

            while (_Running)
            {
                AnsiConsole.Clear();
                AnsiConsole.Write(header);

                // Display instructions
                AnsiConsole.Write(instructions);

                // Display active products
                AnsiConsole.Write(products);

                // Dispaly recent reponse
                _DisplayReponse.Header = responseHeader;
                AnsiConsole.Write(_DisplayReponse);

                // Take user input
                AnsiConsole.Write(input);
                string command = Console.ReadLine();
            }
        }

        public void Close() => _Running = false;

        public event EventHandler<CommandEnteredEventArgs> CommandEntered;

        private void OnCommandEntered(CommandEnteredEventArgs e)
        {
            if (CommandEntered != null) CommandEntered(this, e);
        }

        public void UserNotFound(string username) =>
            _DisplayReponse = new Panel("");
            /* _DisplayReponse = () => Console.WriteLine($"User [{username}] not found!"); */

        public void ProductNotFound(string product) =>
            _DisplayReponse = new Panel("");
            /* _DisplayReponse = () => Console.WriteLine($"Product [{product}] not found!"); */

        public void UserInfo(User user)
        {
            string transactions = "";
            foreach (Transaction t in _Stregsystem.GetTransactions(user, 10))
            {
                transactions += t + "\n";
            }

            _DisplayReponse = new Panel
            (
                user + "\n" +
                "Username: " + user.Username + "\n" +
                "Balance: " + user.Balance + "\n" +
                (user.Balance < 50 ? "Warning balance under 50\n" : "") + "\n" +
                "Purchases\n" +
                transactions
            );
        }
            /* _DisplayReponse = () => */
            /* { */
            /*     Console.WriteLine(user); */
            /*     Console.WriteLine($"Username: {user.Username}"); */
            /*     Console.WriteLine($"Balance: {user.Balance}"); */
            /*     if (user.Balance < 50) */
            /*         Console.WriteLine("Warning balance under 50"); */

            /*     Console.WriteLine(""); */
            /*     Console.WriteLine("Purchases"); */
            /*     foreach(Transaction t in _Stregsystem.GetTransactions(user, 10)) */
            /*     { */
            /*         Console.WriteLine(t); */
            /*     } */
            /* }; */

        public void TooManyArgumentsError(string command) =>
            _DisplayReponse = new Panel("");
            /* _DisplayReponse = () => Console.WriteLine($"Command [{command}] has too many arguments!"); */

        public void UserBuysProduct(BuyTransaction transaction) =>
            _DisplayReponse = new Panel("");
            /* _DisplayReponse = () => Console.WriteLine(transaction); */

        public void UserBuysProduct(int n, BuyTransaction transaction) =>
            _DisplayReponse = new Panel("");
            /* _DisplayReponse = () => Console.WriteLine($"{transaction}x{n}."); */

        public void GeneralError(string errorString) =>
            _DisplayReponse = new Panel("");
            /* _DisplayReponse = () => Console.WriteLine($"Error: {errorString}"); */

        public void InsufficientCash(User user, Product product) =>
            _DisplayReponse = new Panel("");
            /* _DisplayReponse = () => Console.WriteLine */
            /* ( */
            /*     $"{user} tried purchasing {product} while only having a balance of {user.Balance}." */
            /* ); */
    }
}
