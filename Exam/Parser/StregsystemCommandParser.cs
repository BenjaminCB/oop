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
            }
            else
            {
                StregsystemUI.GeneralError("Unknown command!");
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
                int id = Int32.Parse(args[0]);
                Product p = Stregsystem.GetProductById(id);
                p.CanBeBoughtOnCredit = val;
                StregsystemUI.GeneralMessage($"{p} can be bought on credit value set to: {val}");
            }
            catch (ProductIdNotFoundException)
            {
                StregsystemUI.ProductNotFound(args[0]);
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

    }
}
