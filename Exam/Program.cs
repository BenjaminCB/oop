using Exam.Controller;
using Exam.Logic;
using Exam.UI;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            IStregsystem stregsystem = new Stregsystem();
            IStregsystemUI stregsystemUI = new StregsystemCLI(stregsystem);
            StregsystemController controller = new StregsystemController(stregsystem, stregsystemUI);
            controller.StregsystemUI.Start();
        }
    }
}
