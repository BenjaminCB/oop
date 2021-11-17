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

            Panel instructionsPanel = new Panel("These are the instructions");
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

                // add response panel
                _DisplayReponse.Header = responseHeader;
                _DisplayReponse.Expand = true;
                table.AddColumn(new TableColumn(_DisplayReponse));

                AnsiConsole.Write(table);

                // Display instructions
                AnsiConsole.Write(instructionsPanel);

                // Take user input
                AnsiConsole.Write(input);
                string command = Console.ReadLine();
            }
        }

        private Table _ProductTable()
        {
            var table = new Table()
                .AddColumn(new TableColumn("ID"))
                .AddColumn(new TableColumn("Product"))
                .AddColumn(new TableColumn("Price"));

            foreach (Product p in _Stregsystem.ActiveProducts)
            {
                // Spectre seems a little funky when using AddRow
                // so i have to convert to strings manually
                double price = (double) p.Price / 100;
                table.AddRow(p.Id.ToString(), p.Name, price.ToString());
            }

            return table;
        }

        public void Close() => _Running = false;

        public event EventHandler<CommandEnteredEventArgs> CommandEntered;

        private void OnCommandEntered(CommandEnteredEventArgs e)
        {
            if (CommandEntered != null) CommandEntered(this, e);
        }

        public void UserNotFound(string username) =>
            _DisplayReponse = new Panel($"User [{username}] not found!");

        public void ProductNotFound(string product) =>
            _DisplayReponse = new Panel($"Product [{product}] not found!");

        public void UserInfo(User user)
        {
            string transactions = "";
            foreach (Transaction t in _Stregsystem.GetTransactions(user, 10))
            {
                transactions += t + "\n";
            }

            string warning = user.Balance < 50 ? "Warning balance under 50" : "";

            _DisplayReponse = new Panel
            (
                String.Join( '\n'
                           , user
                           , $"Username: {user.Username}"
                           , $"Balance: {user.Balance}"
                           , warning
                           , "Purchases"
                           , transactions )
            );
        }

        public void TooManyArgumentsError(string command) =>
            _DisplayReponse = new Panel($"Command [{command}] has too many arguments!");

        public void UserBuysProduct(BuyTransaction transaction) =>
            _DisplayReponse = new Panel(transaction.ToString());

        public void UserBuysProduct(int n, BuyTransaction transaction) =>
            _DisplayReponse = new Panel($"{transaction}x{n}");

        public void GeneralError(string errorString) =>
            _DisplayReponse = new Panel($"Error: {errorString}");

        public void InsufficientCash(User user, Product product) =>
            _DisplayReponse = new Panel
            (
                $"{user} tried purchasing {product} while only having a balance of {user.Balance}."
            );
    }
}
