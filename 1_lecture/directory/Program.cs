using System;
using System.IO;

namespace directory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MyDirectory.FileSizes();

            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
            MyDirectory.Tree(di);
        }
    }
}
