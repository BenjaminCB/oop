using Exam.Logic;
using Exam.UI;
using Exam.Parser;

namespace Exam.Controller
{
    public class StregsystemController
    {
        public IStregsystem Stregsystem { get; }
        public IStregsystemUI StregsystemUI { get; }
        public StregsystemCommandParser Parser { get; }

        public StregsystemController(IStregsystem stregsystem, IStregsystemUI stregsystemUI)
        {
            Stregsystem = stregsystem;
            StregsystemUI = stregsystemUI;
            Parser = new StregsystemCommandParser(stregsystem, stregsystemUI);

            Stregsystem.UserBalanceWarning += HandleUserBalanceWarning;
            StregsystemUI.CommandEntered += (_,args) => Parser.ParseCommand(args.Command);
        }

        void HandleUserBalanceWarning(object sender, UserBalanceWarningEventArgs args)
        {
            // TODO display warning
        }
    }
}
