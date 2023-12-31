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

            // assign event handlers to the events
            // this ignores the object reference parameter that comes from using
            // EventHandler which is the delegate that c# docs recommend
            Stregsystem.UserBalanceWarning += (_,args) =>
                StregsystemUI.GeneralMessage($"User [{args.User.Username}] balance is below 50!");
            StregsystemUI.CommandEntered += (_,args) => Parser.ParseCommand(args.Command);
        }
    }
}
