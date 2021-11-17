using System;
using System.IO;
using Exam.Parser;
using System.Collections.Generic;
using System.Linq;
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
            stregsystemUI.UserInfo(stregsystem.GetUsers(u => true).First());
            stregsystemUI.Start();
        }
    }
}
