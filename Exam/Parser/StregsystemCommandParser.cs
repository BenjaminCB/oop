using System;
using System.Collections.Generic;
using System.Linq;
using Exam.Logic;
using Exam.UI;
using Exam.Exception;

namespace Exam.Parser
{
    public class StregsystemCommandParser
    {
        public IStregsystem Stregsystem { get; }
        public IStregsystemUI StregsystemUI { get; }
        private Dictionary<string, Action<string[]>> _AdminCommands;

        public StregsystemCommandParser(IStregsystem stregsystem, IStregsystemUI stregsystemUI)
        {
            Stregsystem = stregsystem;
            StregsystemUI = stregsystemUI;

            _AdminCommands = new Dictionary<string, Action<string[]>>();
            _AdminCommands.Add(":quit", _Quit);
            _AdminCommands.Add(":q", _Q);
            _AdminCommands.Add(":activate", _Activate);
            _AdminCommands.Add(":deactivate", _Deactivate);
            _AdminCommands.Add(":crediton", _CreditOn);
            _AdminCommands.Add(":creditoff", _CreditOff);
            _AdminCommands.Add(":addcredits", _AddCredits);
        }

        public void ParseCommand(string command)
        {
            string[] words = command.Split(' ');
            string cmd = words.First();
            string[] args = words.Skip(1).ToArray();

            if (_AdminCommands.ContainsKey(cmd))
            {
                _AdminCommands[cmd](args);
                return;
            }

            // if it is not an admin command we will try and parse it as a user command
            // if users get any more commands a dictionary should probably be used for this as well
            switch (args.Length)
            {
                case 0:
                    _UserInfo(cmd);
                    break;
                case 1:
                    _QuickBuy(cmd, args.First());
                    break;
                case 2:
                    _MultiBuy(cmd, args.First(), args.Last());
                    break;
                default:
                    StregsystemUI.TooManyArgumentsError(cmd);
                    break;
            }
        }

        private void _Quit(string[] args) => _QuitGeneral(":quit", args);
        private void _Q(string[] args) => _QuitGeneral(":q", args);
        private void _QuitGeneral(string cmd, string[] args)
        {
            if (args.Length > 0)
            {
                StregsystemUI.ArgumentsCountError(cmd, 0);
            }
            else
            {
                StregsystemUI.Close();
            }
        }

        // TODO refactor _ActivateGeneral and _CreditGeneral
        // TODO refactor argument length checker
        private void _Activate(string[] args) => _ActivateGeneral(":activate", true, args);
        private void _Deactivate(string[] args) => _ActivateGeneral(":deactivate", false, args);
        private void _ActivateGeneral(string cmd, bool val, string[] args)
        {
            if (args.Length != 1)
            {
                StregsystemUI.ArgumentsCountError(cmd, 1);
                return;
            }

            try
            {
                int id = Int32.Parse(args[0]);
                Product p = Stregsystem.GetProductById(id);
                p.Active = val;
                StregsystemUI.GeneralMessage($"{p} active value set to: {val}");
            }
            catch (InactiveProductException e)
            {
                StregsystemUI.GeneralMessage(e.Message);
            }
            catch (System.Exception e)
            {
                StregsystemUI.GeneralError(e.Message);
            }
        }

        private void _CreditOn(string[] args) => _CreditGeneral(":crediton", true, args);
        private void _CreditOff(string[] args) => _CreditGeneral(":creditoff", false, args);
        private void _CreditGeneral(string cmd, bool val, string[] args)
        {
            if (args.Length != 1)
            {
                StregsystemUI.ArgumentsCountError(cmd, 1);
                return;
            }

            try
            {
                int id = Int32.Parse(args.First());
                Product p = Stregsystem.GetProductById(id);
                p.CanBeBoughtOnCredit = val;
                StregsystemUI.GeneralMessage($"{p} can be bought on credit value set to: {val}");
            }
            catch (ProductIdNotFoundException)
            {
                StregsystemUI.ProductNotFound(args.First());
            }
            catch (System.Exception e)
            {
                StregsystemUI.GeneralError(e.Message);
            }
        }


        private void _AddCredits(string[] args)
        {
            if (args.Length != 2)
            {
                StregsystemUI.ArgumentsCountError(":addcredits", 2);
                return;
            }

            string username = args.First();

            try
            {
                int coin = Int32.Parse(args.Last());

                User u = Stregsystem.GetUserByUsername(username);
                Transaction t = new InsertCashTransaction(u, coin);
                Stregsystem.ExecuteTransaction(t);

                StregsystemUI.GeneralMessage(t.ToString());
            }
            catch (UsernameNotFoundException)
            {
                StregsystemUI.UserNotFound(username);
            }
            catch (System.Exception e)
            {
                StregsystemUI.GeneralError(e.Message);
            }
        }

        private void _UserInfo(string username)
        {
            try
            {
                User u = Stregsystem.GetUserByUsername(username);
                StregsystemUI.UserInfo(u);
            }
            catch (UsernameNotFoundException)
            {
                StregsystemUI.UserNotFound(username);
            }
        }

        private void _QuickBuy(string username, string id)
        {
            try
            {
                User u = Stregsystem.GetUserByUsername(username);
                Product p = Stregsystem.GetProductById(Int32.Parse(id));

                BuyTransaction t = new BuyTransaction(u, p);
                Stregsystem.ExecuteTransaction(t);

                StregsystemUI.UserBuysProduct(t);
            }
            catch (UsernameNotFoundException)
            {
                StregsystemUI.UserNotFound(username);
            }
            catch (ProductIdNotFoundException)
            {
                StregsystemUI.ProductNotFound(id);
            }
            catch (InsufficientCreditsExceptions e)
            {
                StregsystemUI.InsufficientCash(e.User, e.Product);
            }
            catch (System.Exception e)
            {
                StregsystemUI.GeneralError(e.Message);
            }
        }

        // since multibuy should treat this as multiple transactions
        // we will just try to get as many succesful transactions as possible
        private void _MultiBuy(string username, string n, string id)
        {
            try
            {
                User u = Stregsystem.GetUserByUsername(username);
                Product p = Stregsystem.GetProductById(Int32.Parse(id));

                for (int i = 0; i < Int32.Parse(n); i++)
                {
                    BuyTransaction t = new BuyTransaction(u, p);
                    Stregsystem.ExecuteTransaction(t);

                    StregsystemUI.UserBuysProduct(t);
                }
            }
            catch (UsernameNotFoundException)
            {
                StregsystemUI.UserNotFound(username);
            }
            catch (ProductIdNotFoundException)
            {
                StregsystemUI.ProductNotFound(id);
            }
            catch (InsufficientCreditsExceptions e)
            {
                StregsystemUI.InsufficientCash(e.User, e.Product);
            }
            catch (System.Exception e)
            {
                StregsystemUI.GeneralError(e.Message);
            }
        }

    }
}
