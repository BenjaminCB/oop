using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Parser
{
    public abstract class CSVParser<T>
    {
        private FileInfo _File { get; }
        private string _ErrorLog { get; }
        protected char _Delimiter { get; }

        public CSVParser(FileInfo file, char delimiter)
        {
            _File = file;
            _Delimiter = delimiter;
            _ErrorLog = Path.Combine(Directory.GetCurrentDirectory(), "Data", "parse_errors.txt");
        }

        public IEnumerable<T> Parse()
        {
            List<T> successes = new List<T>();

            // go through all the lines and try to parse them
            // if any error occurs we simply skip it we log it
            using (StreamWriter file = File.AppendText(_ErrorLog))
            {
                foreach (string s in File.ReadAllLines(_File.FullName).Skip(1))
                {
                    try
                    {
                        successes.Add(_ParseLine(s));
                    }
                    catch (System.Exception e)
                    {
                        file.WriteLine(e.Message);
                    }
                }
            }

            return successes;
        }

        protected abstract T _ParseLine(string s);
    }
}
