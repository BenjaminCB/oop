using System;
using Spectre.Console;
using Exam.Logic;

namespace Exam.UI
{
    public class StregsystemCLI : IStregsystemUI
    {
        private IStregsystem _Stregsystem;
        private FixedQueue<string> _Responses;
        private bool _Running;

        public StregsystemCLI(IStregsystem stregsystem)
        {
            _Stregsystem = stregsystem;
            _Running = false;

            // the latest responses that the system outputs to the user
            _Responses = new FixedQueue<string>(4);
            _Responses.Enqueue("Once you enter some commands the responses will appear here");
        }

        public void Start()
        {
            // we should not be able to start the UI if it is already running
            if (_Running) return;

            _Running = true;

            // create various UI elements
            Rule header = new Rule("[bold]STREGSYSTEM[/]");
            header.Centered();
            Rule input = new Rule("[bold]INPUT[/]");
            input.Centered();

            Panel instructionsPanel = new Panel(String.Join('\n'
                    , "To buy a single product type your username followed by the product id."
                    , "To buy a product multiple times type your username followed by the amount you want followed by the product id."
                    , "To see information about your account simply type your username" ));
            instructionsPanel.Header = new PanelHeader("[bold]Instructions[/]");
            instructionsPanel.Expand = true;

            PanelHeader responseHeader = new PanelHeader("[bold]Responses[/]");

            while (_Running)
            {
                AnsiConsole.Clear();
                AnsiConsole.Write(header);

                // Create table that will contain the product table and response panel
                Table table = new Table();
                table.Border = TableBorder.None;

                // product table
                table.AddColumn(new TableColumn(_ProductTable()));

                // response table
                table.AddColumn(new TableColumn(_ResponseTable()));

                AnsiConsole.Write(table);

                // Display instructions
                AnsiConsole.Write(instructionsPanel);

                // Take user input
                AnsiConsole.Write(input);
                string command = Console.ReadLine();

                // upon entered command create and throw event
                CommandEnteredEventArgs args = new CommandEnteredEventArgs();
                args.Command = command;
                OnCommandEntered(args);
            }
        }

        // create table of all the active products
        private Table _ProductTable()
        {
            var table = new Table()
                .AddColumn(new TableColumn("[bold]ID[/]"))
                .AddColumn(new TableColumn("[bold]Product[/]"))
                .AddColumn(new TableColumn("[bold]Price[/]"));

            foreach (Product p in _Stregsystem.ActiveProducts)
                table.AddRow(p.Id.ToString(), p.Name, p.Price.ToString());

            return table;
        }

        // create a table of containing all the latest responses
        private Table _ResponseTable()
        {
            var table = new Table()
                .AddColumn(new TableColumn("[bold]Latest Reponses[/]"));

            table.Border = TableBorder.Minimal;

            foreach (string s in _Responses)
                table.AddRow(s.EscapeMarkup());

            return table;
        }

        public void Close() => _Running = false;

        public event EventHandler<CommandEnteredEventArgs> CommandEntered;

        private void OnCommandEntered(CommandEnteredEventArgs e)
        {
            // if an event handler is defined call it
            if (CommandEntered != null) CommandEntered(this, e);
        }

        public void UserNotFound(string username) =>
            _Responses.Enqueue($"User [{username}] not found!");

        public void ProductNotFound(string product) =>
            _Responses.Enqueue($"Product [{product}] not found!");

        public void UserInfo(User user)
        {
            string transactions = "";
            foreach (Transaction t in _Stregsystem.GetTransactions(user, 10))
            {
                transactions += t + "\n";
            }

            string warning = user.Balance < 50 ? "Warning balance under 50" : "";

            _Responses.Enqueue( String.Join( '\n'
                              , user
                              , $"Username: {user.Username}"
                              , $"Balance: {user.Balance}"
                              , warning
                              , "Purchases"
                              , transactions ));
        }

        public void ArgumentsCountError(string command, int n) =>
            _Responses.Enqueue($"Command [{command}] takes {n} argument(s)!");

        public void TooManyArgumentsError(string command) =>
            _Responses.Enqueue($"Too many arguments in command [{command}]!");

        public void UserBuysProduct(BuyTransaction transaction) =>
            _Responses.Enqueue(transaction.ToString());

        public void UserBuysProduct(int n, BuyTransaction transaction) =>
            _Responses.Enqueue($"{transaction}x{n}");

        public void GeneralError(string errorString) =>
            _Responses.Enqueue($"Error: {errorString}");

        public void GeneralMessage(string msg) =>
            _Responses.Enqueue(msg);

        public void InsufficientCash(User user, Product product) =>
            _Responses.Enqueue
            (
                $"{user} tried purchasing {product} while only having a balance of {user.Balance}."
            );
    }
}
