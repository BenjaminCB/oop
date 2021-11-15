using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Parser
{
    public abstract class CSVParser<T>
    {
        private FileInfo _File;
        protected char _Delimiter;

        public CSVParser(FileInfo file, char delimiter)
        {
            _File = file;
            _Delimiter = delimiter;
        }

        public IEnumerable<T> Parse() =>
            File.ReadAllLines(_File.FullName).Skip(1).Select(s => _ParseLine(s));

        protected abstract T _ParseLine(string s);
    }
}
