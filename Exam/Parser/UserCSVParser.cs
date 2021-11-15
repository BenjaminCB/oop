using System;
using System.IO;
using Exam.Logic;

namespace Exam.Parser
{
    public class UserCSVParser : CSVParser<User>
    {
        public UserCSVParser(FileInfo file, char delimiter)
            : base(file, delimiter) {}

        protected override User _ParseLine(string s)
        {
            string[] vals = s.Split(_Delimiter);

            string fullname = vals[1] + " " + vals[2];
            string username = vals[3];
            int balance = Int32.Parse(vals[4]);
            string email = vals[5];

            return new User(fullname, username, balance, email);
        }
    }
}
