using System;
using System.IO;
using Exam.Parser;
using System.Collections.Generic;
using System.Linq;
using Exam.Logic;
using Microsoft.VisualBasic.FileIO;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "users.csv"));
            UserCSVParser parser = new UserCSVParser(file, ',');
            IEnumerable<User> us = parser.Parse();
            foreach (User u in us)
            {
                Console.WriteLine(u);
            }
        }
    }
}
