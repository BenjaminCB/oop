using System;
using System.IO;
using System.Text.RegularExpressions;
using Exam.Logic;

namespace Exam.Parser
{
    public class ProductCSVParser : CSVParser<Product>
    {
        public ProductCSVParser(FileInfo file, char delimiter)
            : base(file, delimiter) {}

        // skips id column
        protected override Product _ParseLine(string s)
        {
            string[] vals = s.Split(_Delimiter);

            // replace html tags and double quotes
            string name = Regex.Replace(vals[1], @"<[^>]+>", m => "").Replace("\"","");

            int price = Int32.Parse(vals[2]);
            bool active = vals[3] == "1";

            return new Product(name, price, active);
        }
    }
}
